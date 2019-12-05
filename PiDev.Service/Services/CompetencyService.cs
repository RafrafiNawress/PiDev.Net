using MoreLinq;
using Newtonsoft.Json;
using PiDev.Data;
using PiDev.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PiDev.Service.Services
{
    public class CompetencyService
    {
        public string GetJobs()
        {
            var url = "http://localhost:9080/pidev-web/rest/jobs";
            var webrequest = (HttpWebRequest)WebRequest.Create(url);
            string result;
            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        public string GetJobCompetencies(int id)
        {
            var url = "http://localhost:9080/pidev-web/rest/jobs/" + id;
            var webrequest = (HttpWebRequest)WebRequest.Create(url);
            string result;
            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        public void AssignJob(int empId, int jobId)
        {
            using(Context dbc = new Context())
            {
                employee emp = dbc.employees.Find(empId);
                job job = dbc.jobs.Find(jobId);
                if(emp != null && job != null)
                {
                    emp.job = job;
                    job.employees.Add(emp);
                    dbc.SaveChanges();
                }
            }
        }

        public string GetEmployees(int jobId)
        {
            string result = "[]";
            using (Context c = new Context())
            {
                if (jobId == -1)
                {
                    result = JsonConvert.SerializeObject(c.employees.Select(x => new { id = x.id, firstName = x.firstname, lastName = x.lastname, jobId = x.job_id, jobName = (x.job != null ? x.job.name + " level " + x.job.level : ""), score=0 }).ToList());
                } else
                {
                    job target = c.jobs.Find(jobId);
                    if (target.competencies == null || target.competencies.Count == 0)
                    {
                        result = "[]";
                    }
                    else
                    {
                        List<employee> emps = c.employees.Where(e => e.job != null && e.job_id != jobId).ToList();
                        var list = emps.Select(x => new { id = x.id, firstName = x.firstname, lastName = x.lastname, jobId = x.job_id, jobName = (x.job != null ? x.job.name + " level " + x.job.level : ""), score = 0 }).ToList();
                        for (int i = 0; i < list.Count; i++)
                        {
                            int score = 0;
                            job current = emps[i].job;
                            if (current != null)
                            {
                                for (int j = 0; j < target.competencies.Count; j++)
                                {
                                    competency targetComp = target.competencies.ToList()[j];
                                    competency currentComp = current.competencies.Where(comp => comp.name == targetComp.name).SingleOrDefault();
                                    if (currentComp != null)
                                    {
                                        score += Math.Abs(targetComp.level - currentComp.level);
                                    }
                                    else
                                    {
                                        score += targetComp.level;
                                    }
                                }
                            }
                            list[i] = new { id = list[i].id, firstName = list[i].firstName, lastName = list[i].lastName, jobId = list[i].jobId, jobName = list[i].jobName, score = score };
                        }
                        result = JsonConvert.SerializeObject(list);
                    }
                }
            }
            return result;
        }

        public string GetCompetenciesOverview()
        {
            string result = "";
            using(Context dbc = new Context())
            {
                var competencies = dbc.competencies.DistinctBy(comp=>comp.name).ToList();
                var resultList = competencies.Select(c => new { name = c.name, value = 0f }).ToList();
                var emps = dbc.employees.Where(e => e.job != null).ToList();
                int globalTotal = 0;
                for (int i = 0; i < competencies.Count; i++)
                {
                    int total = 0;
                    for(int j=0;j< emps.Count; j++)
                    {
                        job empJob = emps[j].job;
                        if(empJob != null && empJob.competencies != null && empJob.competencies.Count > 0)
                        {
                            total += empJob.competencies.Count(c => c.name == competencies[i].name);
                        }
                    }
                    globalTotal += total;
                    resultList[i] = new { name = resultList[i].name, value = (float)total };
                }
                for (int i = 0; i < resultList.Count; i++)
                {

                    resultList[i] = new { name = resultList[i].name, value = (resultList[i].value/globalTotal)*100 };
                }
                    result = JsonConvert.SerializeObject(resultList);
            }
            return result;
        }

        public string GetEmployeesByCompetency(string compName)
        {
            //competency c = new competency();
            //c.name = "communication";
            //c.description = "can talk";
            //c.level = 1;
            //string data = JsonConvert.SerializeObject(c);


            //var url = "http://localhost:9080/pidev-web/rest/generic";
            //var webrequest = (HttpWebRequest)WebRequest.Create(url);
            //webrequest.Method = "POST";
            //webrequest.ContentType = "application/json";
  
            //webrequest.ContentLength = data.Length;
            //using (Stream webStream = webrequest.GetRequestStream())
            //using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
            //{
            //    requestWriter.Write(data);
            //}


            string result = "";
            using(Context dbc = new Context())
            {
                var initialList = dbc.employees.Where(e => e.job != null).ToList();

                List<dynamic> list = new List<dynamic>();
                for (int i=0;i<initialList.Count; i++)
                {
                    var comps = initialList[i].job.competencies;
                    if (comps != null && comps.Any(com => com.name == compName))
                    {
                        list.Add(new { id = initialList[i].id, firstName = initialList[i].firstname, lastName = initialList[i].lastname, jobId = initialList[i].job_id, jobName = (initialList[i].job != null ? initialList[i].job.name + " level " + initialList[i].job.level : "") });
                    }
                }
                 result = JsonConvert.SerializeObject(list);
            }
            return result;
        }
    }
}
