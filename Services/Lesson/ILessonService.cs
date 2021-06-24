using System;

namespace TopcoderNetApi.Services.Lesson
{
    public interface ILessonService
    {
       Model.Lesson GetLesson(Guid id);
    }
}
