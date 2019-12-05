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
            string result = "";
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
                        result = JsonConvert.SerializeObject(c.employees.Select(x => new { id = x.id, firstName = x.firstname, lastName = x.lastname, jobId = x.job_id, jobName = (x.job != null ? x.job.name + " level " + x.job.level : ""), score = 0 }).ToList());
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
    }
}
