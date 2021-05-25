using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PFE_EMI.Migrations
{
    public partial class CreateIdentitySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Professeur",
                columns: table => new
                {
                    ID_prof = table.Column<string>(nullable: false),
                    Fname = table.Column<string>(nullable: true),
                    Lname = table.Column<string>(nullable: true),
                    Disponible = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professeur", x => x.ID_prof);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roleName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Departement",
                columns: table => new
                {
                    code_ID = table.Column<string>(nullable: false),
                    nom = table.Column<string>(nullable: true),
                    ID_chef = table.Column<string>(nullable: true),
                    ProfesseurID_prof = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departement", x => x.code_ID);
                    table.ForeignKey(
                        name: "FK_Departement_Professeur_ProfesseurID_prof",
                        column: x => x.ProfesseurID_prof,
                        principalTable: "Professeur",
                        principalColumn: "ID_prof",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfessorDepartment",
                columns: table => new
                {
                    ID_prof = table.Column<string>(nullable: false),
                    ID_departement = table.Column<string>(nullable: true),
                    Departementcode_ID = table.Column<string>(nullable: true),
                    ProfesseurID_prof = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorDepartment", x => x.ID_prof);
                    table.ForeignKey(
                        name: "FK_ProfessorDepartment_Departement_Departementcode_ID",
                        column: x => x.Departementcode_ID,
                        principalTable: "Departement",
                        principalColumn: "code_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfessorDepartment_Professeur_ProfesseurID_prof",
                        column: x => x.ProfesseurID_prof,
                        principalTable: "Professeur",
                        principalColumn: "ID_prof",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Specialite",
                columns: table => new
                {
                    ID_specialty = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    code_dept = table.Column<string>(nullable: true),
                    Departementcode_ID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialite", x => x.ID_specialty);
                    table.ForeignKey(
                        name: "FK_Specialite_Departement_Departementcode_ID",
                        column: x => x.Departementcode_ID,
                        principalTable: "Departement",
                        principalColumn: "code_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Etudiant",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Fname = table.Column<string>(nullable: true),
                    Lname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Branch = table.Column<string>(nullable: true),
                    Specialty = table.Column<string>(nullable: true),
                    Departementcode_ID = table.Column<string>(nullable: true),
                    SPESID_specialty = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiant", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Etudiant_Departement_Departementcode_ID",
                        column: x => x.Departementcode_ID,
                        principalTable: "Departement",
                        principalColumn: "code_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Etudiant_Specialite_SPESID_specialty",
                        column: x => x.SPESID_specialty,
                        principalTable: "Specialite",
                        principalColumn: "ID_specialty",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DemandesEncadrements",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Etudiant = table.Column<int>(nullable: false),
                    ID_Prof = table.Column<string>(nullable: true),
                    liens_complementaires = table.Column<string>(nullable: true),
                    SujetPFE = table.Column<string>(nullable: true),
                    date_depot = table.Column<DateTime>(nullable: false),
                    ETAT = table.Column<int>(nullable: false),
                    EtudiantID = table.Column<int>(nullable: true),
                    ProfesseurID_prof = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemandesEncadrements", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DemandesEncadrements_Etudiant_EtudiantID",
                        column: x => x.EtudiantID,
                        principalTable: "Etudiant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DemandesEncadrements_Professeur_ProfesseurID_prof",
                        column: x => x.ProfesseurID_prof,
                        principalTable: "Professeur",
                        principalColumn: "ID_prof",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PFE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_student = table.Column<int>(nullable: false),
                    id_prof = table.Column<string>(nullable: true),
                    ProfesseurID_prof = table.Column<string>(nullable: true),
                    lien_PFE = table.Column<string>(nullable: true),
                    sujet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PFE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PFE_Professeur_ProfesseurID_prof",
                        column: x => x.ProfesseurID_prof,
                        principalTable: "Professeur",
                        principalColumn: "ID_prof",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PFE_Etudiant_id_student",
                        column: x => x.id_student,
                        principalTable: "Etudiant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RemarquesProf",
                columns: table => new
                {
                    id_remarque = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_prof = table.Column<string>(nullable: true),
                    id_student = table.Column<int>(nullable: false),
                    remarque = table.Column<string>(nullable: true),
                    liens_complementaires = table.Column<string>(nullable: true),
                    seen = table.Column<bool>(nullable: false),
                    date_remarque = table.Column<DateTime>(nullable: false),
                    ProfesseurID_prof = table.Column<string>(nullable: true),
                    EtudiantID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemarquesProf", x => x.id_remarque);
                    table.ForeignKey(
                        name: "FK_RemarquesProf_Etudiant_EtudiantID",
                        column: x => x.EtudiantID,
                        principalTable: "Etudiant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RemarquesProf_Professeur_ProfesseurID_prof",
                        column: x => x.ProfesseurID_prof,
                        principalTable: "Professeur",
                        principalColumn: "ID_prof",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DemandesEncadrements_EtudiantID",
                table: "DemandesEncadrements",
                column: "EtudiantID");

            migrationBuilder.CreateIndex(
                name: "IX_DemandesEncadrements_ProfesseurID_prof",
                table: "DemandesEncadrements",
                column: "ProfesseurID_prof");

            migrationBuilder.CreateIndex(
                name: "IX_Departement_ProfesseurID_prof",
                table: "Departement",
                column: "ProfesseurID_prof");

            migrationBuilder.CreateIndex(
                name: "IX_Etudiant_Departementcode_ID",
                table: "Etudiant",
                column: "Departementcode_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Etudiant_SPESID_specialty",
                table: "Etudiant",
                column: "SPESID_specialty");

            migrationBuilder.CreateIndex(
                name: "IX_PFE_ProfesseurID_prof",
                table: "PFE",
                column: "ProfesseurID_prof");

            migrationBuilder.CreateIndex(
                name: "IX_PFE_id_student",
                table: "PFE",
                column: "id_student",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorDepartment_Departementcode_ID",
                table: "ProfessorDepartment",
                column: "Departementcode_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorDepartment_ProfesseurID_prof",
                table: "ProfessorDepartment",
                column: "ProfesseurID_prof");

            migrationBuilder.CreateIndex(
                name: "IX_RemarquesProf_EtudiantID",
                table: "RemarquesProf",
                column: "EtudiantID");

            migrationBuilder.CreateIndex(
                name: "IX_RemarquesProf_ProfesseurID_prof",
                table: "RemarquesProf",
                column: "ProfesseurID_prof");

            migrationBuilder.CreateIndex(
                name: "IX_Specialite_Departementcode_ID",
                table: "Specialite",
                column: "Departementcode_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DemandesEncadrements");

            migrationBuilder.DropTable(
                name: "PFE");

            migrationBuilder.DropTable(
                name: "ProfessorDepartment");

            migrationBuilder.DropTable(
                name: "RemarquesProf");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Etudiant");

            migrationBuilder.DropTable(
                name: "Specialite");

            migrationBuilder.DropTable(
                name: "Departement");

            migrationBuilder.DropTable(
                name: "Professeur");
        }
    }
}
