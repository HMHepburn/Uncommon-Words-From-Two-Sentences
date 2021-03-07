public string[] UncommonFromSentences(string A, string B)
        {
            // Used to keep track of indices for each array
            int numWordsA;
            int numWordsB;

            // Count spaces to calculate the amount of words required
            numWordsA = A.Count(x => x == ' ');
            numWordsA++;
            numWordsB = B.Count(x => x == ' ');
            numWordsB++;

            // Instantiate arrays with number of words for each index
            string[] sentenceA = new string[numWordsA];
            string[] sentenceB = new string[numWordsB];

            int wordStartIndex = 0;
            int wordEndIndex = 0;

            int arrayIndex = 0;

            // Isolating substring 'words' into each array for the first sentence
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == ' ')
                {
                    sentenceA[arrayIndex] = A.Substring(wordStartIndex, wordEndIndex);
                    wordStartIndex = i + 1;
                    wordEndIndex = 0;
                    arrayIndex++;
                }
                else if (i == (A.Length - 1))
                {
                    wordEndIndex++;
                    sentenceA[arrayIndex] = A.Substring(wordStartIndex, wordEndIndex);
                }
                else
                {
                    wordEndIndex++;
                }
            }

            wordStartIndex = 0;
            wordEndIndex = 0;
            arrayIndex = 0;

            // Isolating substring 'words' into each array for the second sentence
            for (int i = 0; i < B.Length; i++)
            {
                if (B[i] == ' ')
                {
                    sentenceB[arrayIndex] = B.Substring(wordStartIndex, wordEndIndex);
                    wordStartIndex = i + 1;
                    wordEndIndex = 0;
                    arrayIndex++;
                }
                else if (i == (B.Length - 1))
                {
                    wordEndIndex++;
                    sentenceB[arrayIndex] = B.Substring(wordStartIndex, wordEndIndex);
                }
                else
                {
                    wordEndIndex++;
                }
            }

            // Arrays must be copied over using a function
            // Inserting an array into another upon initialization will cause them to share the same memory
            string[] tempArrayA = (string[])sentenceA.Clone();
            string[] tempArrayB = (string[])sentenceB.Clone();

            int numWordsATemp = numWordsA;
            int numWordsBTemp = numWordsB;

            // Removing duplicate words in sentence A
            for (int i = 0; i < sentenceA.Length; i++)
            {
                for (int j = 0; j < sentenceB.Length; j++)
                {
                    if (sentenceA[i] == tempArrayB[j])
                    {
                        sentenceA[i] = null;
                        numWordsATemp--;
                    }
                }
                int wordCounter = 0;
                for (int j = 0; j < sentenceA.Length; j++)
                {
                    if (sentenceA[i] == tempArrayA[j] && wordCounter != 0)
                    {
                        sentenceA[i] = null;
                        numWordsATemp--;
                    }
                    else if (sentenceA[i] == tempArrayA[j])
                    {
                        wordCounter++;
                    }
                }
            }

            // Removing duplicate words in sentence B
            for (int i = 0; i < sentenceB.Length; i++)
            {
                for (int j = 0; j < sentenceA.Length; j++)
                {
                    if (sentenceB[i] == tempArrayA[j])
                    {
                        sentenceB[i] = null;
                        numWordsBTemp--;
                    }
                }
                int wordCounter = 0;
                for (int j = 0; j < sentenceB.Length; j++)
                {
                    if (sentenceB[i] == tempArrayB[j] && wordCounter != 0)
                    {
                        sentenceB[i] = null;
                        numWordsATemp--;
                    }
                    else if (sentenceB[i] == tempArrayB[j])
                    {
                        wordCounter++;
                    }
                }
            }

            // Inserting non-duplicate words into a new array to be returned by the function
            string[] uniqueWords = new string[numWordsATemp + numWordsBTemp];
            int index = 0;

            for (int i = 0; i < sentenceA.Length; i++)
            {
                if (sentenceA[i] != null)
                {
                    uniqueWords[index] = sentenceA[i];
                    index++;
                }
            }

            for (int i = 0; i < sentenceB.Length; i++)
            {
                if (sentenceB[i] != null)
                {
                    uniqueWords[index] = sentenceB[i];
                    index++;
                }
            }
            return uniqueWords;
        }