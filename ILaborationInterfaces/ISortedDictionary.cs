using System.Collections.Generic;
using System;

namespace LaborationInterfaces
{
    /// <summary>
    /// MySortedDictionary, kan ses som en tabell med poster. Varje post har en söknyckel och
	/// ett värde. Posternas nycklar är unika, det förekommer inte flera poster med lika nycklar.
    /// Det är möjligt att sätta in nya poster, söka efter poster och ta bort poster. Det går att
    /// ändra på en posts värde men det går inte att ändra på den nyckel som en post har. Det är
    /// möjligt att besöka alla poster sorterade efter posternas nycklar i växande ordning.
    /// </summary>
    /// <typeparam name="KeyType">Typparameter för posternas nycklar</typeparam>
	/// <typeparam name="ValueType">Typparameter för posternas värden</typeparam>
    /// 
    /// Utvecklat av Hans-Edy Mårtensson
    /// Ändrad den 2021-05-09  Hans-Edy Mårtensson
    ///            2022-05-08  Rikard Land          Justering av namespace, för att passa 
    ///                                             i 2022 kursinstans våren 2022
    /// </summary>
    public interface ISortedDictionary<KeyType, ValueType>
        where KeyType : IComparable<KeyType>
    {
        /// <summary>
        /// Antal poster.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Lägge till en ny post med en unik nyckel och dess värde.
        /// Om det redan finns en post med en nyckel som överenstämmer
        /// med nya postens nyckel kastas ett ArgumentException.
        /// </summary>
        /// <param name="key">Den söknyckel som hör till värdet</param>
        /// <param name="value">Det värde som ska läggas till</param>
        void Add(KeyType key, ValueType value);

        /// <summary>
        /// Besöker alla poster i nycklarnas växande ordning. Varje post
        /// utgör argument till den metod som action delegerar till.
        /// </summary>
        /// <param name="action">Delegerar till den metod som är argument
        /// i anrop till Traverse</param>
        void Traverse(Action<KeyValuePair<KeyType, ValueType>> action);

        /// <summary>
        /// Returnerar true eller false beroende på om det finns en post
        /// vars nyckel överenstämmer med key.
        /// </summary>
        /// <param name="key">key är nyckeln till den sökta posten</param>
        /// <returns>true om noden finns, i annat fall false</returns>
        bool Contains(KeyType key);

        /// <summary>
        /// Returnerar en kopia av värdet i den post vars nyckel överenstämmer
        /// med söknyckeln. Om det inte finns en post vars nyckel överenstämmer
        /// med söknyckeln kastas ett ArgumentException.
        /// </summary>
        /// <param name="Key">Söknyckeln</param>
        /// <returns>Det sökta värdet</returns>
        ValueType Get(KeyType key);

        /// <summary>
        /// Ersätter postens värde med newValue. Om det inte finns någon
        /// post vars nyckel överenstämmer med söknyckeln kastas ett
        /// ArgumentException
        /// </summary>
        /// <param name="key">Värdets söknyckel</param>
        /// <param name="newValue">Det nya värdet som ska tilldelas posten</param>
        void Set(KeyType key, ValueType newValue);

        /// <summary>
        /// Tar bort den post vars söknyckel överensstämmer med key. Om det inte
        /// finns någon post vars nyckel överenstämmer med söknyckeln kastas ett
        /// ArgumentException
        /// </summary>
        /// <param name="key">Nyckel till den post som ska tas bort</param>
        void Remove(KeyType key);
    }
}