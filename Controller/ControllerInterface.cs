using Model;

namespace Controller
{
    public class ControllerInterface
    {
        private ModelControl _model;

        public ControllerInterface(ModelControl model)
        {
            _model = model;
        }

        public void JudgeCategory(string selectedValue)
        {
            _model.JudgeCategory(selectedValue);
        }
    }
}