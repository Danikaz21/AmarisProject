using AmarisTest.Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace AmarisTest.Controllers
{
    public class EmployeeController : Controller
    {
       
        [HttpGet]
        public async Task<ActionResult> GetEmployee(string idEmployee)
        {
            List<Employee> lstEmployees = new List<Employee>();
            string baseURL = "https://dummy.restapiexample.com/";
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseURL);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("api/v1/employee/" + idEmployee);

                    if (response.IsSuccessStatusCode)
                    {
                        var respEmployees = response.Content.ReadAsStringAsync().Result;
                        dynamic dynResult = JsonConvert.DeserializeObject(respEmployees);
                        lstEmployees.Add(new Employee()
                        {
                            id = (string)dynResult.data.id,
                            employee_name = (string)dynResult.data.employee_name,
                            employee_age = (string)dynResult.data.employee_age,
                            employee_salary = (int)dynResult.data.employee_salary,
                            profile_image = (string)dynResult.data.profile_image
                        });
                    }
                    else
                    {
                        ViewData["Message"] = response.StatusCode + " - " + response.ReasonPhrase;
                    }
                    return View("Employee", lstEmployees);
                }
            }
            catch (Exception ex)
            {
                return View("Employee", lstEmployees);
            }
        }

        public async Task<ActionResult> Employee()
        {
            List<Employee> lstEmployees = new List<Employee>();
            string baseURL = "https://dummy.restapiexample.com/";

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseURL);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("api/v1/employees");

                    if (response.IsSuccessStatusCode)
                    {
                        var respEmployees = response.Content.ReadAsStringAsync().Result;
                        dynamic dyn = JsonConvert.DeserializeObject(respEmployees);
                        foreach (var item in dyn.data)
                        {
                            lstEmployees.Add(new Employee()
                            {
                                id = item.id,
                                employee_name = item.employee_name,
                                employee_age = item.employee_age,
                                employee_salary = item.employee_salary,
                                profile_image = item.profile_image
                            });
                        }
                    }
                    else
                    {
                        ViewData["Message"] = response.StatusCode + " - " + response.ReasonPhrase;
                    }
                    return View(lstEmployees);
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
    }
}