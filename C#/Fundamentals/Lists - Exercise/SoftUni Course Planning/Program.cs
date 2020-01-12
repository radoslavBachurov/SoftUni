using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "course start")
            {
                string[] commandArr = command.Split(":").ToArray();

                if (command.Contains("Add"))
                {
                    AddCommand(commandArr, lessons);
                }

                else if (command.Contains("Insert"))
                {
                    InsertCommand(commandArr, lessons);
                }

                else if (command.Contains("Remove"))
                {
                    RemoveCommand(commandArr, lessons);
                }

                else if (command.Contains("Swap"))
                {
                    SwapCommand(commandArr, lessons);
                }
                else if (command.Contains("Exercise"))
                {
                    ExerciseCommand(commandArr, lessons);
                }
            }

            for (int i = 0; i < lessons.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{lessons[i]}");
            }

        }

        private static void ExerciseCommand(string[] commandArr, List<string> lessons)
        {
            string exerciseLesson = commandArr[1];
            string formToAdd = exerciseLesson + "-Exercise";

            if (lessons.Contains(exerciseLesson) && !lessons.Contains(formToAdd))
            {
                lessons.Insert(lessons.IndexOf(exerciseLesson) + 1, formToAdd);
            }

            else if (!lessons.Contains(exerciseLesson))
            {
                lessons.Add(exerciseLesson);
                lessons.Add(formToAdd);
            }
        }

        private static void SwapCommand(string[] commandArr, List<string> lessons)
        {
            string firstLesson = commandArr[1];
            string secondLesson = commandArr[2];
            int indexOfFirst = lessons.IndexOf(firstLesson);
            int indexOfSecond = lessons.IndexOf(secondLesson);

            if (indexOfFirst + 1 < lessons.Count && (lessons[indexOfFirst + 1].Contains("Exercise")
                || indexOfSecond + 1 < lessons.Count && lessons[indexOfSecond + 1].Contains("Exercise")))
            {
                SwappingLessonsWithExercises(indexOfFirst, indexOfSecond, lessons);
            }

            else if (lessons.Contains(firstLesson) && lessons.Contains(secondLesson))
            {
                string temp = lessons[indexOfFirst];
                lessons[indexOfFirst] = lessons[indexOfSecond];
                lessons[indexOfSecond] = temp;
            }
        }

        private static void SwappingLessonsWithExercises(int indexOfFirst, int indexOfSecond, List<string> lessons)
        {
            if (indexOfFirst + 1 < lessons.Count && (lessons[indexOfFirst + 1].Contains("Exercise")
                && indexOfSecond + 1 < lessons.Count && lessons[indexOfSecond + 1].Contains("Exercise")))
            {
                string temp = lessons[indexOfFirst];
                string tempExercise = lessons[indexOfFirst + 1];
                lessons[indexOfFirst] = lessons[indexOfSecond];
                lessons[indexOfFirst + 1] = lessons[indexOfSecond + 1];
                lessons[indexOfSecond] = temp;
                lessons[indexOfSecond + 1] = tempExercise;
            }

            else if (indexOfFirst + 1 < lessons.Count && lessons[indexOfFirst + 1].Contains("Exercise"))
            {
                string temp = lessons[indexOfFirst];
                string tempExercise = lessons[indexOfFirst + 1];
                lessons[indexOfFirst] = lessons[indexOfSecond];
                lessons.Insert(indexOfSecond, temp);
                lessons.Insert(indexOfSecond + 1, tempExercise);
                lessons.RemoveAt(indexOfFirst + 1);
            }

            else if (indexOfSecond + 1 < lessons.Count && lessons[indexOfSecond + 1].Contains("Exercise"))
            {
                string temp = lessons[indexOfSecond];
                string tempExercise = lessons[indexOfSecond + 1];
                lessons[indexOfSecond] = lessons[indexOfFirst];
                lessons[indexOfFirst] = temp;
                lessons.RemoveAt(indexOfSecond + 1);
                lessons.Insert(indexOfFirst + 1, tempExercise);
            }
        }

        private static void RemoveCommand(string[] commandArr, List<string> lessons)
        {
            string lessonToRemove = commandArr[1];

            if (lessons.Contains(lessonToRemove))
            {
                int lessonIndex = lessons.IndexOf(lessonToRemove);
                lessons.Remove(lessonToRemove);

                if (lessonIndex + 1 < lessons.Count && lessons[lessonIndex + 1].Contains("Exercise"))
                {
                    lessons.RemoveAt(lessonIndex + 1);
                }
            }
        }

        private static void InsertCommand(string[] commandArr, List<string> lessons)
        {
            int indexToAdd = int.Parse(commandArr[2]);
            string lessonToAdd = commandArr[1];

            if (!lessons.Contains(lessonToAdd))
            {
                lessons.Insert(indexToAdd, lessonToAdd);
            }
        }

        private static void AddCommand(string[] commandArr, List<string> lessons)
        {
            string lessonToAdd = commandArr[1];

            if (!lessons.Contains(lessonToAdd))
            {
                lessons.Add(lessonToAdd);
            }
        }
    }
}
