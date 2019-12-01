using System;
using System.Collections.Generic;
using System.Text;
using Task02.Models;
using Task02.Storages;
using System.IO;

namespace Task02.Storages
{
    /// <summary>
    /// Storage based on list.
    /// </summary>
    internal class Storage : IStorage
    {
        private List<BankAccount> bankAccounts;
        private static readonly string path = AppDomain.CurrentDomain.BaseDirectory + "Accounts.dat";

        /// <summary>
        /// Initializes a new instance of the <see cref="Storage"/> class.
        /// </summary>
        public Storage()
        {
            this.bankAccounts = this.ReadFromFile();
        }

        /// <summary>
        /// Create a bank account.
        /// </summary>
        /// <param name="bankAccount">The account.</param>
        public void Create(BankAccount bankAccount)
        {
            this.bankAccounts.Add(bankAccount);
            this.AddToFile(bankAccount);
        }

        /// <summary>
        /// Uodates a bank account.
        /// </summary>
        /// <param name="bankAccount">The account.</param>
        public void Update(BankAccount bankAccount)
        {
            int i = this.bankAccounts.FindIndex(c => c.Id == bankAccount.Id);
            this.bankAccounts.RemoveAt(i);
            this.bankAccounts.Insert(i, bankAccount);
            this.UpdateToFile(this.bankAccounts);
        }

        /// <summary>
        /// Gets the bank account by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="BankAccount"/></returns>
        public BankAccount GetById(string id)
        {
            int i = this.bankAccounts.FindIndex(c => c.Id == id);
            return this.bankAccounts[i];
        }

        private void AddToFile(BankAccount bankAccount)
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Append)))
                {
                    writer.Write(bankAccount.Id);
                    writer.Write((int)bankAccount.Status);
                    writer.Write(bankAccount.balance);
                    writer.Write(bankAccount.bonusPoints);
                    writer.Write(bankAccount.user.FirstName);
                    writer.Write(bankAccount.user.LastName);
                    writer.Write((int)bankAccount.AccountType);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private List<BankAccount> ReadFromFile()
        {
            List<BankAccount> bankAccounts = new List<BankAccount>();

            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
                {
                    while (reader.PeekChar() > -1)
                    {
                        string id = reader.ReadString();
                        int status = reader.ReadInt32();
                        decimal balance = reader.ReadDecimal();
                        int bonusPoints = reader.ReadInt32();
                        string userFirstName = reader.ReadString();
                        string userLastName = reader.ReadString();
                        int accountType = reader.ReadInt32();

                        User user = new User(userFirstName, userLastName);
                        BankAccount bankAccount;
                        switch ((int)accountType)
                        {
                            case 0:
                                {
                                    bankAccount = new BaseAccount(id, user, (AccountType)accountType, (AccountStatus)status, balance, bonusPoints);
                                    break;
                                }

                            case 1:
                                {
                                    bankAccount = new GoldAccount(id, user, (AccountType)accountType, (AccountStatus)status, balance, bonusPoints);
                                    break;
                                }

                            case 2:
                                {
                                    bankAccount = new PlatinumAccount(id, user, (AccountType)accountType, (AccountStatus)status, balance, bonusPoints);
                                    break;
                                }

                            default:
                                {
                                    bankAccount = new BaseAccount(id, user, (AccountType)accountType, (AccountStatus)status, balance, bonusPoints);
                                    break;
                                }
                        }

                        bankAccounts.Add(bankAccount);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return bankAccounts;
        }

        private void UpdateToFile(List<BankAccount> bankAccounts)
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Append)))
                {
                    foreach (BankAccount bankAccount in bankAccounts)
                    {
                        writer.Write(bankAccount.Id);
                        writer.Write((int)bankAccount.Status);
                        writer.Write(bankAccount.balance);
                        writer.Write(bankAccount.bonusPoints);
                        writer.Write(bankAccount.user.FirstName);
                        writer.Write(bankAccount.user.LastName);
                        writer.Write((int)bankAccount.AccountType);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Return list of all accounts.
        /// </summary>
        /// <returns>Lsit of accounts.</returns>
        public List<BankAccount> GetAllAccounts()
        {
            return this.bankAccounts;
        }
    }
}
