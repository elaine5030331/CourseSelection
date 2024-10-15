﻿using CourseSelection.Enums;

namespace CourseSelection.Data.Dtos.UserManagementDtos
{
    public class CreateStudentRequest : BaseOperationResult
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public StudentDepartments Department { get; set; }
    }
}