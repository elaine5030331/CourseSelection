using CourseSelection.Data.Dtos.TeacherDtos;
using CourseSelection.Data.Models;
using CourseSelection.Interfaces;
using Dapper;
using System.Data;

namespace CourseSelection.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IDbConnection _connection;

        public TeacherService(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<GetTeacherListResponse> GetTeacherListAsync()
        {
            var sql = @"
                        SELECT 
                            teachers.id AS UserId,
                            users.username AS TeacherName,
                            users.email AS Email,
                            Teachers.Department AS Department,
                            Teachers.Position AS PositionId
                        FROM dbo.teachers
                        JOIN dbo.users ON users.id = teachers.userId";

            var queryString = (await _connection.QueryAsync<TeacherInfo>(sql)).ToList();

            var result = new GetTeacherListResponse()
            {
                TeacherInfos = queryString
            };

            return result;
        }
    }
}
