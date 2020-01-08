using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Services;
using Ninject.Modules;

namespace TestSystem.Util
{
    public class ControllerModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAnswerService>().To<AnswerService>();
            Bind<IQuestionService>().To<QuestionService>();
            Bind<IResultService>().To<ResultService>();
            Bind<IStudentService>().To<StudentService>();
            Bind<ITeacherService>().To<TeacherService>(); 
            Bind<ITestService>().To<TestService>();
        }
    }
}
