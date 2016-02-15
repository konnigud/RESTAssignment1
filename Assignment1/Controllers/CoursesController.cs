using Assignment1.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Net;
using System.Linq;
using System;

namespace Assignment1.Controllers
{
    [RoutePrefix("api/courses")]
    public class CoursesController : ApiController
    {

        private List<Course> _courses;
        private List<Student> _student;
        private List<Tuple<string, int>> _studentInClass;

        public CoursesController()
        {
            if (_courses == null)
            {
                _courses = new List<Course>()
                {
                    new Course() {ID = 1,Name = "Forritun", TemplateID =  "T-111-PROG", StartDate = new System.DateTime(2015,8,17), EndDate = new System.DateTime(2015,12,20)},
                    new Course() {ID = 2,Name = "Stjrál Stærfræði 1", TemplateID =  "T-117-STR1", StartDate = new System.DateTime(2015,8,17), EndDate = new System.DateTime(2015,12,20)},
                    new Course() {ID = 3,Name = "Tölvuhögun", TemplateID =  "T-107TOLH", StartDate = new System.DateTime(2015,8,17), EndDate = new System.DateTime(2015,12,20).Date},
                    new Course() {ID = 4,Name = "Verkefnalausnir", TemplateID =  "T-110-VERK", StartDate = new System.DateTime(2015,8,17), EndDate = new System.DateTime(2015,12,20)},
                    new Course() {ID = 5,Name = "Gagnasafnsfræði", TemplateID =  "T-202-GAG1", StartDate = new System.DateTime(2015,8,17), EndDate = new System.DateTime(2015,12,20)}
                };
            }

            if (_student == null)
            {
                _student = new List<Student>()
                {
                    new Student() {Name = "Alex Ívar Ívarsson", SSN = "01" },
                    new Student() {Name = "Alexander Baldvin Sigurðsson", SSN = "02" },
                    new Student() {Name = "Alexandra Einarsdóttir", SSN = "03" },
                    new Student() {Name = "Andri Fannar Freysson", SSN = "04" },
                    new Student() {Name = "Andri Ívarsson", SSN = "05" },
                    new Student() {Name = "Anton Hilmarsson", SSN = "06" },
                    new Student() {Name = "Arnar Gauti Ingason", SSN = "07" },
                    new Student() {Name = "Arnar Kári Ágústsson", SSN = "08" },
                    new Student() {Name = "Arnar Dóri Ásgeirsson", SSN = "09" },
                    new Student() {Name = "Aron Freyr Heiðarsson", SSN = "10" }
                };
            }

            if (_studentInClass == null)
            {
                _studentInClass = new List<Tuple<string, int>>();
                _studentInClass.Add(Tuple.Create("01", 1));
                _studentInClass.Add(Tuple.Create("02", 1));
                _studentInClass.Add(Tuple.Create("03", 1));
                _studentInClass.Add(Tuple.Create("04", 1));
                _studentInClass.Add(Tuple.Create("05", 1));
                _studentInClass.Add(Tuple.Create("06", 1));
                _studentInClass.Add(Tuple.Create("07", 1));
                _studentInClass.Add(Tuple.Create("08", 1));
                _studentInClass.Add(Tuple.Create("09", 1));
                _studentInClass.Add(Tuple.Create("10", 1));

                _studentInClass.Add(Tuple.Create("01", 2));
                _studentInClass.Add(Tuple.Create("02", 2));
                _studentInClass.Add(Tuple.Create("03", 2));
                _studentInClass.Add(Tuple.Create("04", 2));
                _studentInClass.Add(Tuple.Create("05", 2));

                _studentInClass.Add(Tuple.Create("01", 3));
                _studentInClass.Add(Tuple.Create("02", 4));
            }
        }

        /// <summary>
        /// Returns a list of all classes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public List<Course> GetCourses()
        {
            return _courses;
        }

        /// <summary>
        /// Adds a course to the list _courses
        /// Has to meet precondition
        /// CourseId is unique
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        //add course
        public IHttpActionResult AddCourse(Course course)
        {

            if (course == null
               || string.IsNullOrWhiteSpace(course.Name)
               || course.StartDate > course.EndDate
               || string.IsNullOrWhiteSpace(course.TemplateID)
               || course.ID <= 0)
            {
                return StatusCode(HttpStatusCode.PreconditionFailed);
            }

            foreach (Course c in _courses)
            {
                if (c.ID == course.ID)
                {
                    return Conflict();
                }
            }          
            _courses.Add(course);

            var location = Url.Link("GetCourse", new { id = course.ID });
            return Created(location, course);
        }

        //update course
        /// <summary>
        /// Updates course info
        /// Has to meet precondition
        /// Course id can not be changed
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult UpdateCourse(Course course)
        {
            if (course == null
               || string.IsNullOrWhiteSpace(course.Name)
               || course.StartDate > course.EndDate
               || string.IsNullOrWhiteSpace(course.TemplateID)
               || course.ID <= 0)
            {
                return StatusCode(HttpStatusCode.PreconditionFailed);
            }


            foreach (Course c in _courses)
            {
                if (c.ID == course.ID)
                {
                    c.Name = course.Name;
                    c.EndDate = course.EndDate;
                    c.StartDate = course.StartDate;
                    c.TemplateID = course.TemplateID;

                    return StatusCode(HttpStatusCode.NoContent);
                }
            }
            return StatusCode(HttpStatusCode.NotFound);
        }
        // delete course
        /// <summary>
        /// Deletes course if it exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeleteCourse(int id)
        {

            foreach (Course c in _courses)
            {
                if (c.ID == id)
                {
                    _courses.Remove(c);
                    return StatusCode(HttpStatusCode.NoContent);
                }
            }
            return StatusCode(HttpStatusCode.NotFound);
        }

        // get course
        /// <summary>
        /// Retrives a single course
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}", Name = "GetCourse")]
        public Course GetCourse(int id)
        {
            foreach (Course c in _courses)
            {
                if (c.ID == id)
                {
                    return c;
                }
            }

            throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        // get students in course
        /// <summary>
        /// Retrives all student in a single course
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}/students", Name = "StudentInCourse")]
        public List<Student> GetStudentsInCourse(int id)
        {
            if (!_courses.Exists(c => c.ID == id))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var matches = _studentInClass.Where(p => p.Item2 == id).Select(p => p.Item1);

            var studentsInClass = new List<Student>();

            foreach (string s in matches)
            {
                studentsInClass.Add(_student.Find(p => p.SSN == s));
            }

            return studentsInClass;
        }

        // add student to course
        /// <summary>
        /// Adds student from a course.
        /// Student has to exist in _StudentList
        /// No student can be regiseterd more then once in a course.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="SSN"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{id:int}/students")]
        public IHttpActionResult AddStudentToClass(int id, [FromBody] string SSN)
        {
            if (!_courses.Exists(c => c.ID == id))
            {
                return NotFound();
            }

            if (!_student.Exists(s => s.SSN == SSN))
            {
                return NotFound();
            }

            var newTuple = Tuple.Create(SSN, id);

            if (_studentInClass.Contains(newTuple))
            {
                return Conflict();
            }

            _studentInClass.Add(newTuple);
            var location = Url.Link("StudentInCourse", new { id = id });
            return Created(location,SSN);

        }
    }
}
