namespace RSMEnterpriseIntegrationsAPI.Application.Services
{
    using RSMEnterpriseIntegrationsAPI.Application.DTOs;
    using RSMEnterpriseIntegrationsAPI.Application.Exceptions;
    using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;
    using RSMEnterpriseIntegrationsAPI.Domain.Models;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SalesOrderHeaderService : ISalesOrderHeaderService
    {
        private readonly ISalesOrderHeaderRepository _salesOrderHeaderRepository;
        public SalesOrderHeaderService(ISalesOrderHeaderRepository repository)
        {
            _salesOrderHeaderRepository = repository;
        }

        public async Task<int> CreateSalesOrderHeader(CreateSalesOrderHeaderDto salesOrderHeaderDto)
        {
            if (salesOrderHeaderDto is null )
            {
                throw new BadRequestException("Department info is not valid.");
            }

            SalesOrderHeader SOH = new()
            {
                OrderDate = salesOrderHeaderDto.OrderDate,
                CustomerID = salesOrderHeaderDto.CustomerID,
                BillToAddressID = salesOrderHeaderDto.BillToAddressID,
                ShipMethodID = salesOrderHeaderDto.ShipMethodID,
                SubTotal = salesOrderHeaderDto.SubTotal,
                TaxAmt = salesOrderHeaderDto.TaxAmt,
                Freight = salesOrderHeaderDto.Freight,
                DueDate = salesOrderHeaderDto.DueDate,
                ShipToAddressID = salesOrderHeaderDto.ShipToAddressID,
            };

            return await _salesOrderHeaderRepository.CreateSalesOrderHeader(SOH);
        }

        public async Task<int> DeleteSalesOrderHeader(int id)
        {
            if(id <= 0)
            {
                throw new BadRequestException("Id is not valid.");
            }
            var salesOrderHeader = await ValidateSalesOrderHeaderExistence(id);
            return await _salesOrderHeaderRepository.DeleteSalesOrderHeader(salesOrderHeader);
        }

        public async Task<IEnumerable<GetSalesOrderHeaderDto>> GetAll(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                throw new BadRequestException("Invalid page number or page size");
            }            
            var salesOrderHeaders = await _salesOrderHeaderRepository.GetAllSalesOrderHeader(pageNumber, pageSize);
            List<GetSalesOrderHeaderDto> salesOrderHeaderDto = [];

            foreach (var saleOrderHeader in salesOrderHeaders)
            {
                GetSalesOrderHeaderDto dto = new()
                {
                    SalesOrderHeaderId = saleOrderHeader.SalesOrderHeaderId,
                    CustomerID = saleOrderHeader.CustomerID,
                    BillToAddressID = saleOrderHeader.BillToAddressID,
                    ShipMethodID = saleOrderHeader.ShipMethodID,
                    SubTotal = saleOrderHeader.SubTotal,
                    TaxAmt = saleOrderHeader.TaxAmt,
                    Freight = saleOrderHeader.Freight,   
                    DueDate = saleOrderHeader.DueDate,
                    ShipToAddressID = saleOrderHeader.ShipToAddressID                             
                };

                salesOrderHeaderDto.Add(dto);
            }
                        
            return salesOrderHeaderDto; 
        }

        public async Task<GetSalesOrderHeaderDto?> GetSalesOrderHeaderById(int id)
        {
            if(id <= 0)
            {
                throw new BadRequestException("SalesOrderHeaderId is not valid");
            }

            var saleOrderHeader = await ValidateSalesOrderHeaderExistence(id);
            
            GetSalesOrderHeaderDto dto = new()
            {
                SalesOrderHeaderId = saleOrderHeader.SalesOrderHeaderId,
                CustomerID = saleOrderHeader.CustomerID,
                BillToAddressID = saleOrderHeader.BillToAddressID,
                ShipMethodID = saleOrderHeader.ShipMethodID,
                SubTotal = saleOrderHeader.SubTotal,
                TaxAmt = saleOrderHeader.TaxAmt,
                Freight = saleOrderHeader.Freight,
                DueDate = saleOrderHeader.DueDate,
                ShipToAddressID = saleOrderHeader.ShipToAddressID                                
            };
            return dto;
        }

        public async Task<int> UpdateSalesOrderHeader(UpdateSalesOrderHeaderDto saleOrderHeaderDto)
        {
            if(saleOrderHeaderDto is null)
            {
                throw new BadRequestException("Department info is not valid.");
            }
            var saleOrderHeader = await ValidateSalesOrderHeaderExistence(saleOrderHeaderDto.SalesOrderHeaderId);
            
            saleOrderHeader.SubTotal = saleOrderHeaderDto.SubTotal;
            saleOrderHeader.TaxAmt = saleOrderHeaderDto.TaxAmt;
            saleOrderHeader.Freight = saleOrderHeaderDto.Freight;            
            saleOrderHeader.SalesOrderHeaderId = saleOrderHeaderDto.SalesOrderHeaderId;
            saleOrderHeader.DueDate = saleOrderHeaderDto.DueDate;
            
            return await _salesOrderHeaderRepository.UpdateSalesOrderHeader(saleOrderHeader);
        }

        private async Task<SalesOrderHeader> ValidateSalesOrderHeaderExistence(int id)
        {
            var existingSalesOrderHeader = await _salesOrderHeaderRepository.GetSalesOrderHeaderById(id) 
                ?? throw new NotFoundException($"Sales Order Header with Id: {id} was not found.");

            return existingSalesOrderHeader;
        }

    }
}