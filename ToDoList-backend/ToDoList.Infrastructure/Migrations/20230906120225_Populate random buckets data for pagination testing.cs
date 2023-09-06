using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Infrastructure.Migrations
{
    public partial class Populaterandombucketsdataforpaginationtesting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BucketColorId", "MaxAmountOfTasks", "Name" },
                values: new object[] { 4, 7, "doctor for Tasks" });

            migrationBuilder.UpdateData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BucketCategoryId", "MaxAmountOfTasks", "Name" },
                values: new object[] { 1, 10, "growth for Tasks" });

            migrationBuilder.UpdateData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BucketCategoryId", "BucketColorId", "MaxAmountOfTasks", "Name" },
                values: new object[] { 1, 1, 14, "remember for Tasks" });

            migrationBuilder.InsertData(
                table: "Buckets",
                columns: new[] { "Id", "BucketCategoryId", "BucketColorId", "Description", "IsActive", "MaxAmountOfTasks", "Name" },
                values: new object[,]
                {
                    { 4, 3, 2, null, true, 4, "night for Tasks" },
                    { 5, 1, 3, null, true, 2, "accept for Tasks" },
                    { 6, 1, 2, null, true, 11, "say for Tasks" },
                    { 7, 1, 4, null, true, 2, "and for Tasks" },
                    { 8, 3, 3, null, true, 15, "many for Tasks" },
                    { 9, 2, 1, null, true, 6, "day for Tasks" },
                    { 10, 3, 2, null, true, 11, "bring for Tasks" },
                    { 11, 3, 5, null, true, 10, "watch for Tasks" },
                    { 12, 3, 6, null, true, 10, "fish for Tasks" },
                    { 13, 1, 5, null, true, 15, "authority for Tasks" },
                    { 14, 1, 3, null, true, 7, "science for Tasks" },
                    { 15, 1, 3, null, true, 14, "choose for Tasks" },
                    { 16, 3, 2, null, true, 2, "wife for Tasks" },
                    { 17, 3, 4, null, true, 7, "their for Tasks" },
                    { 18, 1, 1, null, true, 15, "free for Tasks" },
                    { 19, 3, 4, null, true, 2, "fact for Tasks" },
                    { 20, 3, 4, null, true, 5, "list for Tasks" },
                    { 21, 2, 1, null, true, 9, "few for Tasks" },
                    { 22, 3, 5, null, true, 11, "plant for Tasks" },
                    { 23, 3, 5, null, true, 6, "spring for Tasks" },
                    { 24, 1, 6, null, true, 13, "Mrs for Tasks" },
                    { 25, 1, 2, null, true, 10, "goal for Tasks" },
                    { 26, 1, 2, null, true, 10, "activity for Tasks" },
                    { 27, 1, 4, null, true, 5, "at for Tasks" },
                    { 28, 2, 3, null, true, 13, "public for Tasks" },
                    { 29, 3, 1, null, true, 10, "property for Tasks" },
                    { 30, 1, 1, null, true, 11, "identify for Tasks" },
                    { 31, 3, 6, null, true, 7, "either for Tasks" },
                    { 32, 3, 1, null, true, 4, "cold for Tasks" },
                    { 33, 3, 2, null, true, 10, "in for Tasks" },
                    { 34, 3, 3, null, true, 5, "million for Tasks" },
                    { 35, 3, 6, null, true, 14, "bed for Tasks" },
                    { 36, 1, 6, null, true, 10, "generation for Tasks" },
                    { 37, 2, 1, null, true, 5, "factor for Tasks" },
                    { 38, 3, 3, null, true, 7, "those for Tasks" },
                    { 39, 3, 1, null, true, 8, "subject for Tasks" },
                    { 40, 3, 5, null, true, 3, "particular for Tasks" },
                    { 41, 3, 4, null, true, 8, "suggest for Tasks" },
                    { 42, 2, 1, null, true, 4, "sister for Tasks" }
                });

            migrationBuilder.InsertData(
                table: "Buckets",
                columns: new[] { "Id", "BucketCategoryId", "BucketColorId", "Description", "IsActive", "MaxAmountOfTasks", "Name" },
                values: new object[,]
                {
                    { 43, 1, 5, null, true, 15, "way for Tasks" },
                    { 44, 3, 3, null, true, 9, "shoulder for Tasks" },
                    { 45, 1, 5, null, true, 3, "daughter for Tasks" },
                    { 46, 3, 4, null, true, 12, "information for Tasks" },
                    { 47, 1, 3, null, true, 8, "morning for Tasks" },
                    { 48, 3, 2, null, true, 14, "wall for Tasks" },
                    { 49, 2, 1, null, true, 14, "similar for Tasks" },
                    { 50, 3, 1, null, true, 15, "foot for Tasks" },
                    { 51, 2, 3, null, true, 9, "magazine for Tasks" },
                    { 52, 3, 2, null, true, 14, "make for Tasks" },
                    { 53, 1, 4, null, true, 5, "claim for Tasks" },
                    { 54, 3, 4, null, true, 6, "improve for Tasks" },
                    { 55, 3, 2, null, true, 9, "out for Tasks" },
                    { 56, 2, 6, null, true, 10, "from for Tasks" },
                    { 57, 3, 2, null, true, 10, "establish for Tasks" },
                    { 58, 1, 4, null, true, 4, "wide for Tasks" },
                    { 59, 1, 3, null, true, 5, "since for Tasks" },
                    { 60, 2, 6, null, true, 14, "believe for Tasks" },
                    { 61, 3, 5, null, true, 9, "stay for Tasks" },
                    { 62, 1, 6, null, true, 14, "class for Tasks" },
                    { 63, 2, 5, null, true, 3, "probably for Tasks" },
                    { 64, 3, 2, null, true, 9, "he for Tasks" },
                    { 65, 2, 6, null, true, 6, "book for Tasks" },
                    { 66, 1, 4, null, true, 5, "read for Tasks" },
                    { 67, 2, 4, null, true, 4, "your for Tasks" },
                    { 68, 2, 1, null, true, 1, "card for Tasks" },
                    { 69, 3, 4, null, true, 14, "detail for Tasks" },
                    { 70, 2, 4, null, true, 6, "political for Tasks" },
                    { 71, 2, 6, null, true, 4, "describe for Tasks" },
                    { 72, 2, 6, null, true, 15, "send for Tasks" },
                    { 73, 1, 4, null, true, 6, "current for Tasks" },
                    { 74, 2, 5, null, true, 6, "style for Tasks" },
                    { 75, 2, 4, null, true, 3, "defense for Tasks" },
                    { 76, 1, 3, null, true, 7, "treat for Tasks" },
                    { 77, 2, 4, null, true, 15, "gun for Tasks" },
                    { 78, 2, 4, null, true, 6, "brother for Tasks" },
                    { 79, 2, 5, null, true, 8, "later for Tasks" },
                    { 80, 2, 4, null, true, 13, "step for Tasks" },
                    { 81, 2, 5, null, true, 4, "head for Tasks" },
                    { 82, 1, 2, null, true, 4, "before for Tasks" },
                    { 83, 1, 5, null, true, 15, "test for Tasks" },
                    { 84, 2, 3, null, true, 14, "blood for Tasks" }
                });

            migrationBuilder.InsertData(
                table: "Buckets",
                columns: new[] { "Id", "BucketCategoryId", "BucketColorId", "Description", "IsActive", "MaxAmountOfTasks", "Name" },
                values: new object[,]
                {
                    { 85, 1, 3, null, true, 5, "method for Tasks" },
                    { 86, 3, 3, null, true, 9, "during for Tasks" },
                    { 87, 1, 1, null, true, 12, "cause for Tasks" },
                    { 88, 1, 3, null, true, 11, "evening for Tasks" },
                    { 89, 1, 3, null, true, 15, "cost for Tasks" },
                    { 90, 2, 6, null, true, 10, "experience for Tasks" },
                    { 91, 1, 5, null, true, 1, "then for Tasks" },
                    { 92, 1, 4, null, true, 5, "understand for Tasks" },
                    { 93, 1, 6, null, true, 7, "response for Tasks" },
                    { 94, 2, 5, null, true, 2, "much for Tasks" },
                    { 95, 3, 4, null, true, 6, "report for Tasks" },
                    { 96, 3, 5, null, true, 13, "quality for Tasks" },
                    { 97, 1, 1, null, true, 1, "thing for Tasks" },
                    { 98, 2, 5, null, true, 12, "policy for Tasks" },
                    { 99, 3, 2, null, true, 5, "by for Tasks" },
                    { 100, 1, 2, null, true, 11, "alone for Tasks" },
                    { 101, 1, 4, null, true, 13, "none for Tasks" },
                    { 102, 1, 4, null, true, 3, "decide for Tasks" },
                    { 103, 1, 3, null, true, 3, "again for Tasks" },
                    { 104, 3, 1, null, true, 13, "tell for Tasks" },
                    { 105, 1, 6, null, true, 2, "draw for Tasks" },
                    { 106, 1, 3, null, true, 12, "compare for Tasks" },
                    { 107, 3, 6, null, true, 2, "point for Tasks" },
                    { 108, 3, 6, null, true, 8, "standard for Tasks" },
                    { 109, 2, 1, null, true, 4, "phone for Tasks" },
                    { 110, 1, 1, null, true, 8, "society for Tasks" },
                    { 111, 1, 2, null, true, 2, "different for Tasks" },
                    { 112, 2, 6, null, true, 8, "enter for Tasks" },
                    { 113, 1, 3, null, true, 13, "budget for Tasks" },
                    { 114, 2, 2, null, true, 13, "collection for Tasks" },
                    { 115, 1, 5, null, true, 2, "happy for Tasks" },
                    { 116, 1, 5, null, true, 2, "human for Tasks" },
                    { 117, 2, 6, null, true, 3, "white for Tasks" },
                    { 118, 2, 4, null, true, 2, "position for Tasks" },
                    { 119, 3, 5, null, true, 6, "minute for Tasks" },
                    { 120, 3, 5, null, true, 2, "interesting for Tasks" },
                    { 121, 3, 3, null, true, 1, "early for Tasks" },
                    { 122, 1, 1, null, true, 8, "happen for Tasks" },
                    { 123, 1, 6, null, true, 2, "center for Tasks" },
                    { 124, 2, 2, null, true, 4, "hundred for Tasks" },
                    { 125, 1, 1, null, true, 2, "agree for Tasks" },
                    { 126, 2, 2, null, true, 7, "hospital for Tasks" }
                });

            migrationBuilder.InsertData(
                table: "Buckets",
                columns: new[] { "Id", "BucketCategoryId", "BucketColorId", "Description", "IsActive", "MaxAmountOfTasks", "Name" },
                values: new object[,]
                {
                    { 127, 1, 5, null, true, 4, "focus for Tasks" },
                    { 128, 2, 4, null, true, 11, "dark for Tasks" },
                    { 129, 3, 6, null, true, 5, "right for Tasks" },
                    { 130, 1, 3, null, true, 4, "price for Tasks" },
                    { 131, 1, 1, null, true, 6, "civil for Tasks" },
                    { 132, 1, 5, null, true, 5, "herself for Tasks" },
                    { 133, 3, 6, null, true, 4, "notice for Tasks" },
                    { 134, 3, 6, null, true, 11, "type for Tasks" },
                    { 135, 3, 6, null, true, 8, "room for Tasks" },
                    { 136, 3, 3, null, true, 11, "southern for Tasks" },
                    { 137, 1, 6, null, true, 15, "feel for Tasks" },
                    { 138, 2, 6, null, true, 4, "should for Tasks" },
                    { 139, 3, 6, null, true, 3, "modern for Tasks" },
                    { 140, 3, 2, null, true, 4, "drive for Tasks" },
                    { 141, 3, 6, null, true, 15, "who for Tasks" },
                    { 142, 2, 2, null, true, 11, "apply for Tasks" },
                    { 143, 3, 2, null, true, 2, "television for Tasks" },
                    { 144, 2, 1, null, true, 13, "serious for Tasks" },
                    { 145, 1, 4, null, true, 14, "consider for Tasks" },
                    { 146, 1, 5, null, true, 11, "social for Tasks" },
                    { 147, 3, 4, null, true, 6, "language for Tasks" },
                    { 148, 2, 2, null, true, 12, "parent for Tasks" },
                    { 149, 3, 6, null, true, 9, "both for Tasks" },
                    { 150, 1, 5, null, true, 3, "base for Tasks" },
                    { 151, 3, 4, null, true, 6, "especially for Tasks" },
                    { 152, 2, 3, null, true, 2, "on for Tasks" },
                    { 153, 3, 4, null, true, 2, "born for Tasks" },
                    { 154, 1, 2, null, true, 11, "result for Tasks" },
                    { 155, 1, 6, null, true, 7, "help for Tasks" },
                    { 156, 1, 5, null, true, 13, "director for Tasks" },
                    { 157, 3, 6, null, true, 15, "ability for Tasks" },
                    { 158, 1, 2, null, true, 13, "blue for Tasks" },
                    { 159, 3, 1, null, true, 15, "glass for Tasks" },
                    { 160, 3, 4, null, true, 9, "its for Tasks" },
                    { 161, 3, 5, null, true, 15, "month for Tasks" },
                    { 162, 1, 2, null, true, 8, "form for Tasks" },
                    { 163, 3, 2, null, true, 7, "whole for Tasks" },
                    { 164, 3, 5, null, true, 8, "service for Tasks" },
                    { 165, 3, 4, null, true, 12, "total for Tasks" },
                    { 166, 3, 3, null, true, 14, "loss for Tasks" },
                    { 167, 1, 6, null, true, 12, "visit for Tasks" },
                    { 168, 2, 6, null, true, 9, "these for Tasks" }
                });

            migrationBuilder.InsertData(
                table: "Buckets",
                columns: new[] { "Id", "BucketCategoryId", "BucketColorId", "Description", "IsActive", "MaxAmountOfTasks", "Name" },
                values: new object[,]
                {
                    { 169, 3, 6, null, true, 6, "husband for Tasks" },
                    { 170, 3, 2, null, true, 11, "involve for Tasks" },
                    { 171, 2, 1, null, true, 3, "move for Tasks" },
                    { 172, 3, 3, null, true, 3, "artist for Tasks" },
                    { 173, 2, 6, null, true, 9, "always for Tasks" },
                    { 174, 2, 6, null, true, 10, "medical for Tasks" },
                    { 175, 1, 2, null, true, 13, "institution for Tasks" },
                    { 176, 1, 2, null, true, 4, "buy for Tasks" },
                    { 177, 3, 6, null, true, 2, "race for Tasks" },
                    { 178, 2, 3, null, true, 10, "member for Tasks" },
                    { 179, 2, 3, null, true, 4, "environmental for Tasks" },
                    { 180, 2, 4, null, true, 6, "ground for Tasks" },
                    { 181, 1, 6, null, true, 15, "role for Tasks" },
                    { 182, 2, 6, null, true, 1, "tough for Tasks" },
                    { 183, 1, 3, null, true, 3, "party for Tasks" },
                    { 184, 2, 6, null, true, 12, "even for Tasks" },
                    { 185, 2, 4, null, true, 3, "sell for Tasks" },
                    { 186, 3, 1, null, true, 9, "until for Tasks" },
                    { 187, 3, 6, null, true, 7, "join for Tasks" },
                    { 188, 1, 3, null, true, 14, "author for Tasks" },
                    { 189, 1, 1, null, true, 15, "film for Tasks" },
                    { 190, 1, 2, null, true, 9, "music for Tasks" },
                    { 191, 2, 1, null, true, 8, "president for Tasks" },
                    { 192, 3, 4, null, true, 1, "affect for Tasks" },
                    { 193, 1, 1, null, true, 3, "most for Tasks" },
                    { 194, 3, 4, null, true, 14, "customer for Tasks" },
                    { 195, 3, 2, null, true, 4, "carry for Tasks" },
                    { 196, 1, 2, null, true, 8, "indicate for Tasks" },
                    { 197, 2, 4, null, true, 15, "perform for Tasks" },
                    { 198, 2, 2, null, true, 8, "realize for Tasks" },
                    { 199, 1, 2, null, true, 15, "garden for Tasks" },
                    { 200, 3, 1, null, true, 8, "address for Tasks" },
                    { 201, 3, 5, null, true, 6, "forget for Tasks" },
                    { 202, 1, 4, null, true, 15, "fear for Tasks" },
                    { 203, 3, 1, null, true, 7, "item for Tasks" },
                    { 204, 1, 5, null, true, 1, "nation for Tasks" },
                    { 205, 3, 1, null, true, 9, "figure for Tasks" },
                    { 206, 2, 3, null, true, 14, "recognize for Tasks" },
                    { 207, 2, 5, null, true, 5, "although for Tasks" },
                    { 208, 2, 1, null, true, 6, "computer for Tasks" },
                    { 209, 1, 3, null, true, 11, "adult for Tasks" },
                    { 210, 1, 6, null, true, 15, "trouble for Tasks" }
                });

            migrationBuilder.InsertData(
                table: "Buckets",
                columns: new[] { "Id", "BucketCategoryId", "BucketColorId", "Description", "IsActive", "MaxAmountOfTasks", "Name" },
                values: new object[,]
                {
                    { 211, 2, 4, null, true, 12, "represent for Tasks" },
                    { 212, 3, 4, null, true, 10, "bar for Tasks" },
                    { 213, 2, 5, null, true, 13, "article for Tasks" },
                    { 214, 3, 6, null, true, 2, "time for Tasks" },
                    { 215, 3, 5, null, true, 13, "company for Tasks" },
                    { 216, 3, 6, null, true, 7, "there for Tasks" },
                    { 217, 3, 3, null, true, 9, "power for Tasks" },
                    { 218, 1, 6, null, true, 15, "interview for Tasks" },
                    { 219, 3, 1, null, true, 7, "forward for Tasks" },
                    { 220, 3, 4, null, true, 14, "same for Tasks" },
                    { 221, 2, 6, null, true, 1, "level for Tasks" },
                    { 222, 1, 6, null, true, 4, "quickly for Tasks" },
                    { 223, 3, 4, null, true, 15, "actually for Tasks" },
                    { 224, 2, 6, null, true, 9, "you for Tasks" },
                    { 225, 2, 4, null, true, 10, "meeting for Tasks" },
                    { 226, 2, 2, null, true, 15, "thousand for Tasks" },
                    { 227, 1, 4, null, true, 12, "measure for Tasks" },
                    { 228, 3, 5, null, true, 11, "less for Tasks" },
                    { 229, 1, 2, null, true, 9, "clear for Tasks" },
                    { 230, 1, 4, null, true, 2, "expert for Tasks" },
                    { 231, 3, 3, null, true, 15, "word for Tasks" },
                    { 232, 2, 1, null, true, 10, "themselves for Tasks" },
                    { 233, 2, 1, null, true, 10, "size for Tasks" },
                    { 234, 2, 2, null, true, 14, "media for Tasks" },
                    { 235, 2, 3, null, true, 11, "them for Tasks" },
                    { 236, 1, 2, null, true, 14, "along for Tasks" },
                    { 237, 2, 6, null, true, 5, "everything for Tasks" },
                    { 238, 3, 1, null, true, 6, "eye for Tasks" },
                    { 239, 3, 5, null, true, 14, "any for Tasks" },
                    { 240, 3, 3, null, true, 14, "bit for Tasks" },
                    { 241, 3, 4, null, true, 6, "act for Tasks" },
                    { 242, 3, 6, null, true, 2, "leg for Tasks" },
                    { 243, 3, 1, null, true, 11, "once for Tasks" },
                    { 244, 3, 2, null, true, 14, "all for Tasks" },
                    { 245, 2, 6, null, true, 9, "increase for Tasks" },
                    { 246, 1, 3, null, true, 10, "the for Tasks" },
                    { 247, 3, 5, null, true, 5, "suddenly for Tasks" },
                    { 248, 1, 2, null, true, 8, "week for Tasks" },
                    { 249, 3, 4, null, true, 12, "key for Tasks" },
                    { 250, 1, 3, null, true, 2, "national for Tasks" },
                    { 251, 3, 6, null, true, 12, "six for Tasks" },
                    { 252, 3, 4, null, true, 10, "though for Tasks" }
                });

            migrationBuilder.InsertData(
                table: "Buckets",
                columns: new[] { "Id", "BucketCategoryId", "BucketColorId", "Description", "IsActive", "MaxAmountOfTasks", "Name" },
                values: new object[,]
                {
                    { 253, 2, 5, null, true, 5, "board for Tasks" },
                    { 254, 2, 4, null, true, 1, "news for Tasks" },
                    { 255, 1, 4, null, true, 5, "knowledge for Tasks" },
                    { 256, 3, 2, null, true, 11, "exist for Tasks" },
                    { 257, 3, 3, null, true, 5, "impact for Tasks" },
                    { 258, 1, 4, null, true, 5, "agency for Tasks" },
                    { 259, 2, 2, null, true, 2, "issue for Tasks" },
                    { 260, 2, 3, null, true, 9, "begin for Tasks" },
                    { 261, 2, 3, null, true, 14, "break for Tasks" },
                    { 262, 3, 3, null, true, 3, "half for Tasks" },
                    { 263, 2, 5, null, true, 3, "prove for Tasks" },
                    { 264, 3, 4, null, true, 6, "house for Tasks" },
                    { 265, 3, 5, null, true, 2, "site for Tasks" },
                    { 266, 2, 1, null, true, 5, "grow for Tasks" },
                    { 267, 2, 6, null, true, 11, "three for Tasks" },
                    { 268, 3, 2, null, true, 4, "everybody for Tasks" },
                    { 269, 3, 3, null, true, 7, "yourself for Tasks" },
                    { 270, 1, 1, null, true, 2, "middle for Tasks" },
                    { 271, 3, 3, null, false, 13, "our Container" },
                    { 272, 2, 3, null, false, 2, "left Container" },
                    { 273, 3, 5, null, false, 11, "new Container" },
                    { 274, 3, 2, null, false, 6, "discussion Container" },
                    { 275, 2, 2, null, false, 9, "song Container" },
                    { 276, 1, 3, null, false, 11, "foreign Container" },
                    { 277, 2, 6, null, false, 1, "country Container" },
                    { 278, 2, 3, null, false, 2, "majority Container" },
                    { 279, 3, 3, null, false, 11, "like Container" },
                    { 280, 3, 1, null, false, 14, "become Container" },
                    { 281, 1, 6, null, false, 7, "outside Container" },
                    { 282, 3, 1, null, false, 7, "around Container" },
                    { 283, 1, 3, null, false, 7, "difference Container" },
                    { 284, 2, 1, null, false, 3, "store Container" },
                    { 285, 3, 1, null, false, 9, "surface Container" },
                    { 286, 3, 4, null, false, 7, "catch Container" },
                    { 287, 2, 2, null, false, 10, "leader Container" },
                    { 288, 3, 3, null, false, 4, "leave Container" },
                    { 289, 1, 1, null, false, 9, "floor Container" },
                    { 290, 1, 1, null, false, 9, "discover Container" },
                    { 291, 1, 5, null, false, 2, "conference Container" },
                    { 292, 1, 3, null, false, 2, "team Container" },
                    { 293, 1, 5, null, false, 1, "sea Container" },
                    { 294, 2, 3, null, false, 14, "not Container" }
                });

            migrationBuilder.InsertData(
                table: "Buckets",
                columns: new[] { "Id", "BucketCategoryId", "BucketColorId", "Description", "IsActive", "MaxAmountOfTasks", "Name" },
                values: new object[,]
                {
                    { 295, 2, 2, null, false, 1, "fall Container" },
                    { 296, 1, 6, null, false, 14, "listen Container" },
                    { 297, 3, 4, null, false, 13, "share Container" },
                    { 298, 3, 5, null, false, 9, "set Container" },
                    { 299, 2, 3, null, false, 1, "simple Container" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$1kLfbvQLeYw1IgyHee1FTOBnSYnEaFLBefjuC0nz1pEeanmYz0oBG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$bwlSGVK3wArsr2oW4yLlueRHFKamr.0lXMk6bc8qR8xFQeKLcVhOq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$QlZpwA2Q1bFI7xFXOVZuvOhXzXyDtU9sPpXLeREdKmwDO8xR0bKX2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 240);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 241);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 242);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 243);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 244);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 245);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 246);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 247);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 248);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 249);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 250);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 251);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 252);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 253);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 254);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 255);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 256);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 257);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 258);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 259);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 260);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 261);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 262);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 263);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 264);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 265);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 266);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 267);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 268);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 269);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 270);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 271);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 272);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 273);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 274);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 275);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 276);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 277);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 278);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 279);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 280);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 281);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 282);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 283);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 284);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 285);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 286);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 287);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 288);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 289);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 290);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 291);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 292);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 293);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 294);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 295);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 296);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 297);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 298);

            migrationBuilder.DeleteData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 299);

            migrationBuilder.UpdateData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BucketColorId", "MaxAmountOfTasks", "Name" },
                values: new object[] { 1, 15, "Objectivity" });

            migrationBuilder.UpdateData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BucketCategoryId", "MaxAmountOfTasks", "Name" },
                values: new object[] { 2, 15, "Kitchen" });

            migrationBuilder.UpdateData(
                table: "Buckets",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BucketCategoryId", "BucketColorId", "MaxAmountOfTasks", "Name" },
                values: new object[] { 2, 4, 15, "Gym" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$xNoeFcBpV79d9fYx8CFd6OObjMFkm8ZCqDcfeprHsQPl4lqQFZbjm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$xyy47OLG7v4LLFI5hbX.WuyIUc12dSPk0SYzM9Yj/ozb5ew99P.Gq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$nzyq4pwDo2hS4RUF7u7uBOuhGNyWeelD47fMgDL6SSRqhkphRpC42");
        }
    }
}
