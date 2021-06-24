using System;

namespace TopcoderNetApi.Services.Lessons
{
    public interface ILessonService
    {
       Model.Lesson GetLesson(Guid id);
    }
}
