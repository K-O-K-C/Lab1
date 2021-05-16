using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lab1
{
    class XMLDocument1
    {
        public string Name { get; set; }
        public string Identifier { get; set; }
        public string Priority { get; set; }
        public string Requirement { get; set; }
        public string Module { get; set; }
        public string SubModule { get; set; }
        public string TitleAndSteps { get; set; }
        public string RequiredStepResult { get; set; }

        public XMLDocument1(string name, string identifier, string priority,
            string requirement, string module, string subModule, string titleAndSteps,
            string requiredStepResult)
        {
            Name = name;
            Identifier = identifier;
            Priority = priority;
            Requirement = requirement;
            Module = module;
            SubModule = subModule;
            TitleAndSteps = titleAndSteps;
            RequiredStepResult = requiredStepResult;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

