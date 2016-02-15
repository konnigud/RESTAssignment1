# RESTAssignment1
Assignment 1

In this first assignment, you should do the following:

Install Visual Studio (if you haven't already!)
Create a simple Web API
Install Visual Studio

Using Visual Studio 2015 is preferred, although 2013 should work as well. Ensure you install the latest update as well (Visual Studio 2013.3 is apparently the latest for VS 2013).

Create a simple Web API

Your first assignment is to design and create a REST service using ASP.NET Web API. It should model courses and their students.

A course should have the following properties - all required:

Name (Example: "Web Services")
TemplateID (Example: "T-514-VEFT")
ID (Example: 1)
StartDate (Example: 2015-08-17)
EndDate (Example: 2015-11-08)
A student has the following properties - all required:

SSN
Name
It should support the following operations:

Get a list of courses (10%)
Add a course (10%)
Update a course (10%)
Delete a course (10%)
Get a course with a given ID (10%)
Get a list of students in a course (10%)
Add a student to a course (10%)
The service should be designed according to the REST philosophy:

using resources (10%)
using the HTTP verbs (GET, POST, PUT, DELETE) for different operations (10%)
using HTTP status codes correctly (10%). Your code should at least use 404 when requesting a resource which doesn't exist, 201 when creating a resource, 204 when deleting a resource, and 400 (or 412) when trying to create a resource without the required properties.
Note: you *don't* need to store anything in a database (since we haven't covered that in detail!), so you may implement the API by storing all data in memory, for instance using List<>. Example:

public class CoursesController : ApiController
{
    private static List<Course> _courses;

    public CoursesController()
    {
        if (_courses == null )
        {
              _courses = new List<Course>
             {
                 new Course
                 {
                     ID         = 1,
                     Name       = "Web services",
                     TemplateID = "T-514-VEFT",
                     StartDate  = DateTime.Now,
                     EndDate    = DateTime.Now.AddMonths(3)
                 },
                 new Course
                 {
                     // etc.
 

 

Test the API using CURL, which you should install if it isn't already available on your machine (you could also use browser plugins such as Advanced REST Client for Chrome).

Your handin should include at least 2 courses, and each course should have at least 2 students.
