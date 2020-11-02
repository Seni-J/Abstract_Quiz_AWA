using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AbstractQuizzStructure;

public class KwizApiModel : MonoBehaviour
{
    [Serializable]
    public class QuizzesInAPI : Quizzes
    {
        public List<QuizzInAPI> data = new List<QuizzInAPI>();

        public override void MapAPIValuesToAbstractClass()
        {
            foreach(QuizzInAPI quizzdata in this.data)
            {
                quizzdata.MapAPIValuesToAbstractClass();
                base.AddQuizz(quizzdata);
            }
        }
    }

    [Serializable]
    public class QuizzInAPI : Quizz
    {
        public int id;
        public string title;
        public string description;

        public override void MapAPIValuesToAbstractClass()
        {
            base.SetQuizzId(id);
            base.SetQuizzTitle(title);
        }
    }
    [Serializable]
    public class QuestionsInAPI : Questions
    {
        public List<QuestionInAPI> data = new List<QuestionInAPI>();

        public override void MapAPIValuesToAbstractClass()
        {
            foreach (QuestionInAPI questionData in this.data)
            {
                questionData.MapAPIValuesToAbstractClass();
                base.AddQuestion(questionData);
            }
        }
    }

    [Serializable]
    public class QuestionInAPI : Question
    {
        public int id;
        public string question;
        public List<AnswerInAPI> answers = new List<AnswerInAPI>();

        public override void MapAPIValuesToAbstractClass()
        {
            base.SetQuestionid(this.id);
            base.SetQuestionText(question);
        }
    }

    [Serializable]
    public class AnswerInAPI : Answer
    {
        public string value;
        public bool correct;

        public override void MapAPIValuesToAbstractClass()
        {
            base.SetDataToShowAsPossibleAnswer(value);
            base.SetIsCorrectAnswer(correct);
        }
    }
}
