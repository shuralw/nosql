using Microsoft.EntityFrameworkCore;
using nosql.Models;
using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;

namespace nosql
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string nextNode = "/";
            QuestionnaireDBContext questionnaireDBContext = new QuestionnaireDBContext();


            for (int i = 0; i < 1000; i++)
            {
                // Add Questionnaire
                Questionnaire questionnaire = new Questionnaire();
                questionnaire.Id = Guid.NewGuid();
                questionnaireDBContext.Questionnaires.Add(questionnaire);

                // Add Answertype
                Answertype answertype = new Answertype();
                answertype.Id = Guid.NewGuid();
                answertype.Type = "type " + i.ToString();
                questionnaireDBContext.Answertypes.Add(answertype);

                // Add Block
                Block block = new Block();
                block.Id = Guid.NewGuid();
                block.QuestionnaireId = questionnaire.Id;

                string currentNode = nextNode;
                block.Node = HierarchyId.Parse(nextNode);
                nextNode = currentNode + "1/";

                questionnaireDBContext.Blocks.Add(block);

                // Add Question
                Question question = new Question();
                question.Id = Guid.NewGuid();
                question.BlockId = block.Id;
                question.Text = "question " + i.ToString();
                questionnaireDBContext.Questions.Add(question);

                // Add Answer
                Answer answer = new Answer();
                answer.Id = Guid.NewGuid();
                answer.QuestionId = question.Id;
                answer.AnswertypeId = answertype.Id;
                questionnaireDBContext.Answers.Add(answer);
            }
            questionnaireDBContext.SaveChanges();

            // Big List
            Stopwatch swBig = Stopwatch.StartNew();
            var myBigList = questionnaireDBContext.Blocks.Select(b => b).ToList();
            swBig.Stop();
            Console.Write("Big List: ");
            Console.WriteLine(swBig.Elapsed.ToString());


            // Small List
            Stopwatch swSmall = Stopwatch.StartNew();
            var mySmallList = questionnaireDBContext.Blocks
                .Take(10)
                .Select(b => b).ToList();
            swSmall.Stop();
            Console.Write("Small List: ");
            Console.WriteLine(swSmall.Elapsed.ToString());

            // Comparison
            Stopwatch swComparison = Stopwatch.StartNew();
            for (int i = 1; i < 10000; i++)
            {
                var myFirstCompareItem = questionnaireDBContext.Blocks
                    .Skip(i % 100)
                    .First();

                var mySecondCompareItem = questionnaireDBContext.Blocks
                     .Skip((i + 1) % 100)
                     .First();

                bool isEqual = myFirstCompareItem.Id == mySecondCompareItem.Id;

                swSmall.Stop();
            }
            Console.Write("Comparison: ");
            Console.WriteLine(swComparison.Elapsed.ToString());
        }
    }
}

