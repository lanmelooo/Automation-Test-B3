using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Test_B3.Support
{
    public class GlobalVariable
    {
        // Define 'driver' como trigger para os WebElements
        public IWebDriver driver;

        // Define 'fechar navegador ao final do teste' como padrão
        public bool driverQuit = true;

        // Halibita | Desabilita modo Headless
        public bool headlessTest = false;
    }
}
