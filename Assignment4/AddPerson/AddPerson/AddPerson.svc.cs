using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace AddPerson
{
    public class AddPerson : IAddPerson
    {
        /// <summary>
        /// Adds a new person to the XML file by reading the original Persons.xml file
        /// into memory, adding the new person, and then writing back to the Persons.xml file
        /// </summary>
        /// <param name="person"></param>
        public void AddNewPerson(Person person)
        {
            var persons = DeserializePersons();
            persons.Person.Add(person);
            SerializePersons(persons);
        }

        /// <summary>
        /// Removes the specified person from the Persons.xml file
        /// </summary>
        /// <param name="person"></param>
        public void RemovePerson(Person person)
        {
            var persons = DeserializePersons();
            persons = CheckPerson(persons, person);
            SerializePersons(persons);
        }

        /// <summary>
        /// Checks if the User ID exists in the xml file.
        /// Returns true if it already exists
        /// Returns false if it does not
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Returns true if the userId is taken and false otherwise</returns>
        public bool UserIdCheck(string userId)
        {
            var persons = DeserializePersons();
            return persons.Person.Any(p => p.Credential.Id.Equals(userId));
        }

        /// <summary>
        /// Checks if the first and last name already exists in the Persons.xml file
        /// This is simply for the load test data button
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns>Returns true if the first and last name already exists and false otherwise</returns>
        public bool PersonNameCheck(string firstName, string lastName)
        {
            var persons = DeserializePersons();

            foreach (var person in persons.Person)
            {
                if (person.Name.First.Equals(firstName) && person.Name.Last.Equals(lastName))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns the contents of the Persons.xml file in the form of a Persons object
        /// </summary>
        /// <returns>Returns a Persons object that contains the Persons.xml data</returns>
        public Persons GetPersons()
        {
            return DeserializePersons();
        }

        /// <summary>
        /// Deserializes the Persons.xml file and returns a Persons object
        /// </summary>
        /// <returns>A Persons object that contains the Persons.xml data</returns>
        private Persons DeserializePersons()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(Persons));
            using (FileStream fileStream = new FileStream(@"J:\Projects\AddPerson\AddPerson\Data\Persons.xml", FileMode.Open))
            {
                return (Persons)deserializer.Deserialize(fileStream);
            }
        }

        /// <summary>
        /// Serializes the Persons object and rewrites the Persons.xml file
        /// </summary>
        /// <param name="persons"></param>
        private void SerializePersons(Persons persons)
        {
            XmlSerializer serializer = new XmlSerializer(persons.Person.GetType(), new XmlRootAttribute("Persons"));
            using (StreamWriter writer = new StreamWriter(@"J:\Projects\AddPerson\AddPerson\Data\Persons.xml"))
            {
                serializer.Serialize(writer.BaseStream, persons.Person);
            }
        }

        /// <summary>
        /// Checks if a person exists in the Persons.xml file and removes them if they do
        /// </summary>
        /// <param name="persons"></param>
        /// <param name="removePerson"></param>
        /// <returns>Returns the Persons object with the specified person removed</returns>
        private Persons CheckPerson(Persons persons, Person removePerson)
        {
            var index = 0;

            foreach (var person in persons.Person)
            {
                if (removePerson.Credential.Id.Equals(person.Credential.Id))
                {
                    persons.Person.RemoveAt(index);
                    break;
                }
                index++;
            }
            return persons;
        }
    }
}
