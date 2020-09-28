using System;
using System.Collections.Generic;
using UnityEngine;
using static AbstractQuizzStructure;

/**
 *  HerokuApiModel is the class that defines how is structured the API data for Heroku Api
 *  - It maps the data from API to the classes that are used everywhere in the application logic (Quizzes/Quizz/Questions/Question/Answers/Answer)
 */
public class HerokuApiModel : MonoBehaviour
{
    [Serializable]
    public class QuizzesInAPI : Quizzes
    {
        public List<QuizzInAPI> quizzes = new List<QuizzInAPI>();
        
        public override void MapAPIValuesToAbstractClass()
        {
            foreach (QuizzInAPI quizzData in this.quizzes)
            {
                quizzData.MapAPIValuesToAbstractClass(); // Map values for QuizzData to Quizz (QuizzData inherits from Quizz)
                base.AddQuizz(quizzData);
            }
        }
    }

    [Serializable]
    public class QuizzInAPI : Quizz
    {
        public string title;
        public string image;
        public string description;
        public Creator created_by = new Creator();
        public int number_participants;
        public string id;

        public override void MapAPIValuesToAbstractClass()
        {
            base.SetQuizzId(this.id);
            base.SetQuizzTitle(this.title);
        }
    }


    [Serializable]
    public class QuestionsInAPI : Questions
    {
        public string id;
        public string title;
        public string description;
        public string image;
        public string created_by;
        public List<QuestionInAPI> questions = new List<QuestionInAPI>();
        public int number_participants;

        public override void MapAPIValuesToAbstractClass()
        {
            foreach (QuestionInAPI questionData in questions)
            {
                questionData.MapAPIValuesToAbstractClass();
                base.AddQuestion(questionData);
            }
        }
    }

    [Serializable]
    public class QuestionInAPI : Question
    {
        public string id;
        public string question;
        public string image;
        public List<AnswerInAPI> answers = new List<AnswerInAPI>();

        public override void MapAPIValuesToAbstractClass()
        {
            base.SetQuestionText(question);
            base.SetQuestionid(this.id);
        }
    }

    [Serializable]
    public class AnswerInAPI : Answer
    {
        public string name;
        public bool value;

        public override void MapAPIValuesToAbstractClass()
        {
            base.SetDataToShowAsPossibleAnswer(name);
            base.SetIsCorrectAnswer(value);
        }
    }


    [Serializable]
    public class Creator
    {
        string id;
        string username;
    }
}


#region Example of json to class with JsonUtility.FromJson<Class>(JSON_DATA)
/**
 *
 * For example:
 * JSON_DATA: 
 * 
 * {
 *   "data": [
 *      {
 *          "id": 1,
 *          "title": "quizzTitle
 *          "description": "quizzDescription",
 *          "image": "https://i.ytimg.com/vi/U7VmBgp9D9o/maxresdefault.jpg"
 *      },
 *      {
 *          "id": 2,
 *          "title": "quizzTitle
 *          "description": "quizzDescription",
 *          "image": "https://i.ytimg.com/vi/U7VmBgp9D9o/maxresdefault.jpg"
 *      }
 *   ]
 * }
 *  
 *  --> Could be declared as the classes bellow:
 *  ---------------------------------------------------------------------------------
 *  
 *  [Serializable]
 *  public class QuizzesData 
 *  {
 *      public List<QuizzData> data = new List<QuizzData>();
 *  }
 *  
 *  [Serializable]
 *  public class QuizzData 
 *  {
 *      public int id;
 *      public string title;
 *      public string description;
 *      public string image;
 *  }
 *  
 *  --> And used like this:
 *  ---------------------------------------------------------------------------------
 *  
 *   QuizzesData quizzesData = JsonUtility.FromJson<QuizzesData>(JSON_DATA);
 *  
 */

#endregion

