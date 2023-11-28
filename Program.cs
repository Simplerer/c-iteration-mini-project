// the ourAnimals array will store the following: 
string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";

// variables that support data entry
int maxPets = 8;
string? readResult;
string menuSelection = "";

// array used to store runtime data, there is no persisted data
string[,] ourAnimals = new string[maxPets, 6];

// create some initial ourAnimals array entries
for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            break;

        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "loki";
            break;

        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "Puss";
            break;
        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "?";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;
        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;
    }

    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
}

do
{
    // display the top-level menu options

    Console.Clear();

    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine(" 5. Edit an animal’s age");
    Console.WriteLine(" 6. Edit an animal’s personality description");
    Console.WriteLine(" 7. Display all cats with a specified characteristic");
    Console.WriteLine(" 8. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }

    // Console.WriteLine($"You selected menu option {menuSelection}.");
    // Console.WriteLine("Press the Enter key to continue");

    // pause code execution
    // readResult = Console.ReadLine();

    switch (menuSelection)
    {
        case "1":
            // List all of our current pet information
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    Console.WriteLine();
                    for (int j = 0; j < 6; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                }
            }

            Console.WriteLine("\n");

            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "2":
            // Add new animal to ourAnimals
            string anotherPet = "y";
            int petCount = 0;



            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    petCount++;
                }
            }

            if (petCount < maxPets)
            {
                Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {(maxPets - petCount)} more.");
            }

            while (petCount < maxPets && anotherPet == "y")
            {

                bool validEntry = false;
                do
                {
                    Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalSpecies = readResult.ToLower();

                        if (animalSpecies != "dog" && animalSpecies != "cat")
                        {
                            validEntry = false;
                        }
                        else
                        {
                            validEntry = true;
                        }
                    }

                } while (validEntry == false);

                animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();
                do
                {
                    int petAge;
                    Console.WriteLine("Enter the pet's age or enter ? if unknown");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalAge = readResult;
                    }

                    if (animalAge != "?")
                    {
                        // returns a boolean as wall as assigning petAge an int if successfull
                        validEntry = int.TryParse(animalAge, out petAge);
                    }
                    else
                    {
                        validEntry = true;
                    }

                } while (validEntry == false);

                // get a description of the pet's physical appearance/condition - animalPhysicalDescription can be blank.
                do
                {
                    Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalPhysicalDescription = readResult.ToLower();
                        if (animalPhysicalDescription == "")
                        {
                            animalPhysicalDescription = "tbd";
                        }
                    }

                } while (animalPhysicalDescription == "");

                // get a description of the pet's personality - animalPersonalityDescription can be blank.
                do
                {
                    Console.WriteLine("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalPersonalityDescription = readResult.ToLower();
                        if (animalPersonalityDescription == "")
                        {
                            animalPersonalityDescription = "tbd";
                        }
                    }

                } while (animalPersonalityDescription == "");

                // get the pet's nickname. animalNickname can be blank.
                do
                {
                    Console.WriteLine("Enter a nickname for the pet");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalNickname = readResult.ToLower();
                        if (animalNickname == "")
                        {
                            animalNickname = "tbd";
                        }
                    }
                } while (animalNickname == "");

                // store the pet information in the ourAnimals array (zero based)
                ourAnimals[petCount, 0] = "ID #: " + animalID;
                ourAnimals[petCount, 1] = "Species: " + animalSpecies;
                ourAnimals[petCount, 2] = "Age: " + animalAge;
                ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
                ourAnimals[petCount, 4] = "Physical description: " + animalPhysicalDescription;
                ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;


                // increment petCount (the array is zero-based, so we increment the counter after adding to the array)
                petCount = petCount + 1;
                // check maxPet limit
                if (petCount < maxPets)
                {
                    // another pet?
                    Console.WriteLine("Do you want to enter info for another pet (y/n)");

                    do
                    {
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            anotherPet = readResult.ToLower();
                        }

                    } while (anotherPet != "y" && anotherPet != "n");

                }
            }

            if (petCount >= maxPets)
            {
                Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
            }
            break;

        case "3":
            // Ensure animal ages and physical descriptions are complete

            Console.WriteLine("\n");

            int petWithNoDescription = 0;
            int petWithDescription = 0;
            string[] incompleteInfo = new string[8];
            string moreInfo = "y";
            string animalAgeStandIn;
            int petCurrentAge;
            bool isThisANumber;
            int[] incompleteInfoIndex = new int[8];

            do
            {

                for (int i = 0; i < maxPets; i++)
                {
                    if (ourAnimals[i, 0] != "ID #: ")
                    {
                        if (ourAnimals[i, 2] == "Age: ?")
                        {
                            incompleteInfo[petWithNoDescription] = ourAnimals[i, 0];
                            petWithNoDescription++;
                        }
                        else
                        {
                            petWithDescription++;
                        }

                    }
                }

                if (petWithNoDescription == 0)
                {
                    Console.WriteLine("All animals currently have ages listed");
                    moreInfo = "n";
                    continue;
                }

                Console.WriteLine($"You have {petWithNoDescription} animals without age information!\n");
                Console.WriteLine("Would you like to fill out the empty ages?\n (y or n)?");

                do
                {
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        moreInfo = readResult.ToLower();
                    }

                } while (moreInfo != "y" && moreInfo != "n");

                if (moreInfo == "n")
                {
                    continue;
                }
                else
                {

                    foreach (string animalId in incompleteInfo)
                    {

                        for (int i = 0; i < maxPets; i++)
                        {
                            if (ourAnimals[i, 0] == animalId)
                            {
                                Console.WriteLine($"Please Provide the age for the {ourAnimals[i, 1]} with {ourAnimals[i, 0]}!");
                                readResult = Console.ReadLine();
                                if (readResult != null)
                                {

                                    animalAgeStandIn = readResult;
                                    isThisANumber = int.TryParse(animalAgeStandIn, out petCurrentAge);

                                    if (isThisANumber)
                                    {
                                        ourAnimals[i, 2] = "Age: " + animalAgeStandIn;
                                        Console.WriteLine("Info Added!\n");
                                        for (int j = 0; j < 6; j++)
                                        {
                                            Console.WriteLine(ourAnimals[i, j]);
                                        }
                                        Console.WriteLine("\n");
                                    }
                                    else
                                    {
                                        Console.WriteLine("We can try that one again next time.");
                                    }


                                    moreInfo = readResult.ToLower();
                                }
                            }
                        }
                    }
                }

                moreInfo = "n";

            } while (moreInfo == "y");

            moreInfo = "y";

            do
            {

                petWithNoDescription = 0;
                petWithDescription = 0;

                for (int i = 0; i < maxPets; i++)
                {
                    if (ourAnimals[i, 0] != "ID #: ")
                    {
                        if (ourAnimals[i, 4] == "Physical description: tbd" || ourAnimals[i, 4] == "Physical description: ")
                        {
                            incompleteInfoIndex[petWithNoDescription] = i;
                            petWithNoDescription++;
                        }
                        else
                        {
                            petWithDescription++;
                        }

                    }
                }

                if (petWithNoDescription > 0)
                {
                    if (petWithNoDescription == 1)
                    {
                        Console.WriteLine($"{petWithNoDescription} animal left without a physical description");
                    }
                    else
                    {
                        Console.WriteLine($"{petWithNoDescription} animals left without physical descriptions");
                    }

                    int animalArrayIndex;
                    bool validEntry = false;
                    for (int i = 0; i < petWithNoDescription; i++)
                    {

                        animalArrayIndex = incompleteInfoIndex[i];
                        Console.WriteLine($"{ourAnimals[animalArrayIndex, 0]} has no description");
                        Console.WriteLine("Please give some physical details \n");

                        readResult = Console.ReadLine();

                        do
                        {

                            if (readResult != null && readResult.Length > 0)
                            {
                                Console.WriteLine(readResult);
                                ourAnimals[animalArrayIndex, 4] = "Physical description: " + readResult;
                                Console.WriteLine("Info Added!\n");
                                for (int j = 0; j < 6; j++)
                                {
                                    Console.WriteLine(ourAnimals[animalArrayIndex, j]);
                                }
                                Console.WriteLine("\n");
                                validEntry = true;
                            }
                            else
                            {
                                Console.WriteLine("Please enter something!!");
                            }


                        } while (validEntry == false);

                    }
                    moreInfo = "n";
                    continue;
                }
                else
                {
                    moreInfo = "n";
                    continue;
                }

            } while (moreInfo == "y");

            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "4":
            // Ensure animal nicknames and personality descriptions are complete

            bool gotAllInfo = false;


            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    if (ourAnimals[i, 3] == "Nickname: tbd" || ourAnimals[i, 3] == "Nickname: ")
                    {

                        Console.WriteLine($"{ourAnimals[i, 0]} has no nickname!");
                        Console.WriteLine("Shall we give them one? (y,n)");

                        readResult = Console.ReadLine();

                        do
                        {

                            if (readResult != null)
                            {

                                if (readResult == "n")
                                {
                                    Console.WriteLine("OK we will get that later");
                                    gotAllInfo = true;
                                    continue;
                                }
                                else
                                {

                                    Console.WriteLine("what name for the little one?\n");
                                    readResult = Console.ReadLine();
                                    if (readResult != null && readResult.Length > 0)
                                    {
                                        ourAnimals[i, 3] = "Nickname: " + readResult;
                                        Console.WriteLine("Info Added!\n");
                                        for (int j = 0; j < 6; j++)
                                        {
                                            Console.WriteLine(ourAnimals[i, j]);
                                        }
                                        Console.WriteLine("\n");
                                        gotAllInfo = true;
                                    }
                                }
                            }

                        } while (gotAllInfo == false);
                    }
                }
            }


            // basically copy for animals personality 
            // need to have confirmation all animals up to date
            // 

            Console.WriteLine("Challenge Project - please check back soon to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "5":
            // Edit an animal’s age
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "6":
            // Edit an animal’s personality description
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "7":
            // Display all cats with a specified characteristic
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "8":
            // Display all dogs with a specified characteristic
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        default:
            break;
    }

} while (menuSelection != "exit");