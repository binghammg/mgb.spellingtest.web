using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace SpellingTest.Controllers
{
    public class SpellingTestController : Controller
    {

        public ActionResult GetUser()
        {
            // Get List of users


            return View();
        }

        //[HttpPost]
        public ActionResult SelectAction()
        {
            return View();
        }

        //[HttpPost]
        public ActionResult ActionRouting(string Options)
        {
            switch (Options)
            {
                case "1":

                    // Get test list

                    // Display test list
                    return View("SelectTest");
                case "2":
                    return View("RetakeOldTest");
                case "3":
                    return View("ReviewOldTest");
                default:
                    return View("SelectTest");
            }
        }


        //[HttpPost]
        public ActionResult GetTestData( /*string TestId*/ )
        {
            // Get test data for the given TestId

            // Begin the test
            return RedirectToAction("GiveTest");
        }


        //[HttpPost]
        public ActionResult GiveTest( /*receives an object with test data in it */ )
        {
            // check to see if all questions in the test data object have been answered.
            // If all answered, redirect
            //else, return the view, passing in the object again

            var testFinished = false;

            if (!testFinished)
            {
                return View();
            }
            else
            {
                return RedirectToAction("TestComplete");
            }
        }


       // [HttpPost]
        public ActionResult TestComplete()
        {
            return View();
        }

        
       // [HttpPost]
        public ActionResult Speak(string textToSpeak)
        {

            var t = new Thread(() =>
            {
                SpeechSynthesizer synth = new SpeechSynthesizer();
                synth.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Adult, 0, new System.Globalization.CultureInfo("en-US"));
                synth.Speak(textToSpeak);
                synth.SetOutputToNull();

            });

            t.Start();
            t.Join();

            return RedirectToAction("GiveTest");
        }
    }
}
