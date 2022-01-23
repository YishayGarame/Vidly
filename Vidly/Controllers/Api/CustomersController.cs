using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.App_Start;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        private readonly IMapper _mapper;
        private readonly MapperConfiguration config;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
            config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            _mapper = config.CreateMapper();
        }


        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET/api/customers
        public IHttpActionResult GetCustomers(string query= null)
        {

            var customersQuery = _context.Customers
                .Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
            {
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
            }
            
                var customerDtos = customersQuery
                    .ToList()
                    .Select(_mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }  
        
        // GET/api/customers/1
        public IHttpActionResult GetCustomers(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_mapper.Map<Customer,CustomerDto>(customer));
            }

        }

        //Post/api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customer = _mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id),customerDto);
        }

        //Post/api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                return NotFound();

            }
            else
            {
                _context.SaveChanges();
               return Ok(_mapper.Map<CustomerDto, Customer>(customerDto,customerInDb));
            }

        }



        //Delete/api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();

        }
    }
}
