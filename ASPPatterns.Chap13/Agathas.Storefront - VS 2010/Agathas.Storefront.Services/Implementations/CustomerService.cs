using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agathas.Storefront.Infrastructure.Domain;
using Agathas.Storefront.Infrastructure.UnitOfWork;
using Agathas.Storefront.Model.Customers;
using Agathas.Storefront.Services.Interfaces;
using Agathas.Storefront.Services.Mapping;
using Agathas.Storefront.Services.Messaging.CustomerService;
using Agathas.Storefront.Services.ViewModels;

namespace Agathas.Storefront.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _uow;

        public CustomerService(ICustomerRepository customerRepository,
                               IUnitOfWork uow)
        {
            _customerRepository = customerRepository;
            _uow = uow;
        }

        public CreateCustomerResponse CreateCustomer(CreateCustomerRequest request)
        {
            CreateCustomerResponse response = new CreateCustomerResponse();
            Customer customer = new Customer();
            customer.IdentityToken = request.CustomerIdentityToken;
            customer.Email = request.Email;
            customer.FirstName = request.FirstName;
            customer.SecondName = request.SecondName;

            ThrowExceptionIfCustomerIsInvalid(customer);

            _customerRepository.Add(customer);
            _uow.Commit();

            response.Customer = customer.ConvertToCustomerDetailView();

            return response;
        }

        private void ThrowExceptionIfCustomerIsInvalid(Customer customer)
        {
            if (customer.GetBrokenRules().Count() > 0)
            {
                StringBuilder brokenRules = new StringBuilder();
                brokenRules.AppendLine("There were problems saving the Customer:");
                foreach (BusinessRule businessRule in customer.GetBrokenRules())
                {
                    brokenRules.AppendLine(businessRule.Rule);
                }

                throw new CustomerInvalidException(brokenRules.ToString());

            }
        }

        public GetCustomerResponse GetCustomer(GetCustomerRequest request)
        {
            GetCustomerResponse response = new GetCustomerResponse();

            Customer customer = _customerRepository
                                     .FindBy(request.CustomerIdentityToken);

            if (customer != null)
            {
                response.CustomerFound = true;
                response.Customer = customer.ConvertToCustomerDetailView();               
            }
            else
                response.CustomerFound = false;


            return response;
        }

        public ModifyCustomerResponse ModifyCustomer(ModifyCustomerRequest request)
        {
            ModifyCustomerResponse response = new ModifyCustomerResponse();

            Customer customer = _customerRepository
                                         .FindBy(request.CustomerIdentityToken);

            customer.FirstName = request.FirstName;
            customer.SecondName = request.SecondName;
            customer.Email = request.Email;

            ThrowExceptionIfCustomerIsInvalid(customer);

            _customerRepository.Save(customer);
            _uow.Commit();

            response.Customer = customer.ConvertToCustomerDetailView();

            return response;
        }

        public DeliveryAddressModifyResponse ModifyDeliveryAddress(
                                                  DeliveryAddressModifyRequest request)
        {
            DeliveryAddressModifyResponse response =
                                           new DeliveryAddressModifyResponse();

            Customer customer = _customerRepository
                                       .FindBy(request.CustomerIdentityToken);

            DeliveryAddress deliveryAddress = customer.DeliveryAddressBook
                            .Where(d => d.Id == request.Address.Id)
                            .FirstOrDefault();

            if (deliveryAddress != null)
            {
                UpdateDeliveryAddressFrom(request.Address, deliveryAddress);

                _customerRepository.Save(customer);
                _uow.Commit();
            }

            response.DeliveryAddress = deliveryAddress
                                         .ConvertToDeliveryAddressView();

            return response;
        }

        public DeliveryAddressAddResponse AddDeliveryAddress(
                                                    DeliveryAddressAddRequest request)
        {
            DeliveryAddressAddResponse response = new DeliveryAddressAddResponse();
            Customer customer = _customerRepository
                                        .FindBy(request.CustomerIdentityToken);

            DeliveryAddress deliveryAddress = new DeliveryAddress();

            deliveryAddress.Customer = customer;
            UpdateDeliveryAddressFrom(request.Address, deliveryAddress);

            customer.AddAddress(deliveryAddress);

            _customerRepository.Save(customer);
            _uow.Commit();

            response.DeliveryAddress = deliveryAddress
                                         .ConvertToDeliveryAddressView();

            return response;
        }

        private void UpdateDeliveryAddressFrom(
                                     DeliveryAddressView deliveryAddressSource,
                                               DeliveryAddress deliveryAddressToUpdate)
        {
            deliveryAddressToUpdate.Name = deliveryAddressSource.Name;
            deliveryAddressToUpdate.AddressLine1 =
                                           deliveryAddressSource.AddressLine1;
            deliveryAddressToUpdate.AddressLine2 =
                                           deliveryAddressSource.AddressLine2;
            deliveryAddressToUpdate.City = deliveryAddressSource.City;
            deliveryAddressToUpdate.State = deliveryAddressSource.State;
            deliveryAddressToUpdate.Country = deliveryAddressSource.Country;
            deliveryAddressToUpdate.ZipCode = deliveryAddressSource.ZipCode;
        }
    }

}
