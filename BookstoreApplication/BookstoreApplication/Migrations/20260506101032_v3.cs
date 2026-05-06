using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookstoreApplication.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Biography", "Birthday", "FullName" },
                values: new object[,]
                {
                    { 1, "English novelist and essayist.", new DateTime(1903, 6, 25, 0, 0, 0, 0, DateTimeKind.Utc), "George Orwell" },
                    { 2, "British author of Harry Potter.", new DateTime(1965, 7, 31, 0, 0, 0, 0, DateTimeKind.Utc), "J.K. Rowling" },
                    { 3, "American author of horror fiction.", new DateTime(1947, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Stephen King" },
                    { 4, "Queen of mystery writing.", new DateTime(1890, 9, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Agatha Christie" },
                    { 5, "American novelist and Nobel Prize winner.", new DateTime(1899, 7, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Ernest Hemingway" }
                });

            migrationBuilder.InsertData(
                table: "Awards",
                columns: new[] { "Id", "Description", "Name", "YearEstablished" },
                values: new object[,]
                {
                    { 1, "Premier literary award for fiction.", "Booker Prize", 1969 },
                    { 2, "Highest literary honor worldwide.", "Nobel Prize in Literature", 1901 },
                    { 3, "Award for science fiction and fantasy.", "Hugo Award", 1953 },
                    { 4, "Award for mystery writing.", "Edgar Award", 1954 }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Address", "Name", "Website" },
                values: new object[,]
                {
                    { 1, "80 Strand, London", "Penguin Books", "https://www.penguin.co.uk" },
                    { 2, "195 Broadway, New York", "HarperCollins", "https://www.harpercollins.com" },
                    { 3, "1230 Avenue of the Americas, New York", "Simon & Schuster", "https://www.simonandschuster.com" }
                });

            migrationBuilder.InsertData(
                table: "AuthorAwardBridge",
                columns: new[] { "AuthorId", "AwardId", "YearAwarded" },
                values: new object[,]
                {
                    { 1, 2, 1949 },
                    { 1, 3, 1950 },
                    { 1, 4, 1951 },
                    { 2, 1, 2000 },
                    { 2, 3, 2001 },
                    { 2, 4, 2003 },
                    { 3, 2, 1990 },
                    { 3, 3, 1982 },
                    { 3, 4, 1988 },
                    { 4, 2, 1960 },
                    { 4, 3, 1957 },
                    { 4, 4, 1955 },
                    { 5, 1, 1953 },
                    { 5, 2, 1954 },
                    { 5, 4, 1956 }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "ISBN", "PageCount", "PublishedDate", "PublisherId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "978-0451524935", 328, new DateTime(1949, 6, 8, 0, 0, 0, 0, DateTimeKind.Utc), 1, "1984" },
                    { 2, 1, "978-0451526342", 112, new DateTime(1945, 8, 17, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Animal Farm" },
                    { 3, 2, "978-0439708180", 223, new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Utc), 2, "Harry Potter and the Philosopher's Stone" },
                    { 4, 2, "978-0439064873", 251, new DateTime(1998, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc), 2, "Harry Potter and the Chamber of Secrets" },
                    { 5, 3, "978-0307743657", 447, new DateTime(1977, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), 3, "The Shining" },
                    { 6, 3, "978-1501156700", 1138, new DateTime(1986, 9, 15, 0, 0, 0, 0, DateTimeKind.Utc), 3, "It" },
                    { 7, 3, "978-0307743671", 199, new DateTime(1974, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Carrie" },
                    { 8, 4, "978-0062073501", 256, new DateTime(1934, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, "Murder on the Orient Express" },
                    { 9, 4, "978-0062073488", 272, new DateTime(1939, 11, 6, 0, 0, 0, 0, DateTimeKind.Utc), 2, "And Then There Were None" },
                    { 10, 4, "978-0062073525", 256, new DateTime(1936, 1, 6, 0, 0, 0, 0, DateTimeKind.Utc), 3, "The ABC Murders" },
                    { 11, 5, "978-0684801223", 127, new DateTime(1952, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3, "The Old Man and the Sea" },
                    { 12, 5, "978-0684801469", 332, new DateTime(1929, 9, 27, 0, 0, 0, 0, DateTimeKind.Utc), 1, "A Farewell to Arms" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
