using System;
using TopcoderNetApi.Model;

namespace TopcoderNetApi.Services.Lessons
{
    public interface ILessonService
    {
       Lesson GetLesson(Guid id);
    }
}
