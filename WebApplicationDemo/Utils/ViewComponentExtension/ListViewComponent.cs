using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationDemo.Utils.ViewComponentExtension
{
    [ViewComponent(Name ="CustomList")]
    public class ListViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string search)
        {
            var student = await GetStudentList(search);
            return View(student);
        }

        public Task<List<Student>> GetStudentList(string search)
        {
            return Task.Run(() =>
            {
                return new List<Student>()
                {
                    new Student(){Id = 1, Name = "张三"},
                    new Student(){ Id = 2, Name = "李四"},
                    new Student(){ Id = 3, Name = "找打"},
                    new Student(){ Id = 4, Name = "孙子"}
                };
            });
        }

    }

    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
