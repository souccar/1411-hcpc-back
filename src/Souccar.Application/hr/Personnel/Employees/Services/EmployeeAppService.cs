using Abp.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Souccar.Core.Filter;
using Souccar.Core.Services;
using Souccar.hr.Personnel.Employees.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;


namespace Souccar.hr.Personnel.Employees.Services
{
    public class EmployeeAppService :
        AsyncSouccarAppService<Employee, EmployeeDto, int, PagedEmployeeRequestDto, CreateEmployeeDto, UpdateEmployeeDto>, IEmployeeAppService
    {
        private readonly IEmployeeManager _employeeDomainService;
        public EmployeeAppService(IEmployeeManager employeeDomainService) : base(employeeDomainService)
        {
            _employeeDomainService = employeeDomainService;
        }

        protected override IQueryable<Employee> CreateFilteredQuery(PagedEmployeeRequestDto input)
        {
            var list = _employeeDomainService.GetAll();
            if (!input.Keyword.IsNullOrWhiteSpace())
            {
                list = list.Where(x => x.FirstName.Contains(input.Keyword) || x.LastName.Contains(input.Keyword));
            }
            return list;
        }
        [HttpPost]
        public IList<EmployeeDto> GetFilteredQuery(FilterInputDto input)
        {

            //FilterInputItemDto item = new FilterInputItemDto() {Field = "FirstName" , Value ="5",Operator= "gte" };
            ////FilterInputItemDto item1 = new FilterInputItemDto() {Field = "name" , Value ="Mohammad",Operator= "eq" };
            //input.Condition = "and";
            //input.Rules = new List<FilterInputItemDto>() { item };

            var values = input.Rules.Select(f => f.Value).ToArray();



            string predicate = "";

            if (input.Rules != null && input.Rules.Any())
            {
                for (var i = 0; i < input.Rules.Count; i++)
                {
                    string comparison = operators[input.Rules[i].Operator];

                    if (comparison == "StartsWith" || comparison == "EndsWith" || comparison == "Contains")
                    {
                        if (i != input.Rules.Count - 1)
                        {
                            predicate += String.Format("{0}.{1}(@{2}) {3} ", input.Rules[i].Field, comparison, i, input.Condition);

                        }
                        else
                        {
                            predicate += String.Format("{0}.{1}(@{2}) ", input.Rules[i].Field, comparison, i);

                        }
                    }
                    else
                    {
                        if (i != input.Rules.Count - 1)
                        {
                            predicate += String.Format("{0} {1} @{2} {3} ", input.Rules[i].Field, comparison, i, input.Condition);

                        }
                        else
                        {
                            predicate += String.Format("{0} {1} @{2}", input.Rules[i].Field, comparison, i);

                        }
                    }
                }
            }

            var employees = _employeeDomainService.GetAll().Where(predicate, values).ToList();

            return ObjectMapper.Map<List<EmployeeDto>>(employees);
        }

        private readonly IDictionary<string, string> operators = new Dictionary<string, string>
        {
            {"eq", "="},
            {"neq", "!="},
            {"lt", "<"},
            {"lte", "<="},
            {"gt", ">"},
            {"gte", ">="},
            {"sw", "StartsWith"},
            {"ew", "EndsWith"},
            {"co", "Contains"},
            {"in", "In"},
            {"nin", "NotIn"},
        };
    }
}
