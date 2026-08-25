        int[] vetNotOrdenation = new int[100];
        int temp;

        Random random = new Random();
        for (int i = 0; i <vetNotOrdenation.Length; i++){

            vetNotOrdenation[i] = random.Next(1,100);
            Console.Write(vetNotOrdenation[i] + " ");
        }
        
        int n = vetNotOrdenation.Length;
        for (int i = 0; i < n - 1; i++){
            for (int j = 0; j < n - i - 1; j++){
                if(vetNotOrdenation[j] > vetNotOrdenation[j + 1]){

                    temp = vetNotOrdenation[j];
                    vetNotOrdenation[j] = vetNotOrdenation[j+1];
                    vetNotOrdenation[j + 1] = temp;
                }
            }
        }

        
        Console.WriteLine("\nORDENADO");
        for (int i = 0; i < vetNotOrdenation.Length; i++)
        {
            Console.Write(vetNotOrdenation[i] + " ");
        }
        Console.WriteLine();



