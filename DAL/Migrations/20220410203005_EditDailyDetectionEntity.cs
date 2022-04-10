﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class EditDailyDetectionEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyDetection_Lab_LabId",
                table: "DailyDetection");

            migrationBuilder.DropForeignKey(
                name: "FK_DailyDetection_Medicine_MedicineId",
                table: "DailyDetection");

            migrationBuilder.DropForeignKey(
                name: "FK_DailyDetection_Radiology_RadiologyId",
                table: "DailyDetection");

            migrationBuilder.DropForeignKey(
                name: "FK_DailyDetection_Room_RoomId",
                table: "DailyDetection");

            migrationBuilder.DropForeignKey(
                name: "FK_DailyDetection_Surgery_SurgeryId",
                table: "DailyDetection");

            migrationBuilder.DropForeignKey(
                name: "FK_DailyDetection_Treatment_TreatmentId",
                table: "DailyDetection");

            migrationBuilder.DropIndex(
                name: "IX_DailyDetection_LabId",
                table: "DailyDetection");

            migrationBuilder.DropIndex(
                name: "IX_DailyDetection_MedicineId",
                table: "DailyDetection");

            migrationBuilder.DropIndex(
                name: "IX_DailyDetection_RadiologyId",
                table: "DailyDetection");

            migrationBuilder.DropIndex(
                name: "IX_DailyDetection_RoomId",
                table: "DailyDetection");

            migrationBuilder.DropIndex(
                name: "IX_DailyDetection_SurgeryId",
                table: "DailyDetection");

            migrationBuilder.DropIndex(
                name: "IX_DailyDetection_TreatmentId",
                table: "DailyDetection");

            migrationBuilder.DropColumn(
                name: "LabId",
                table: "DailyDetection");

            migrationBuilder.DropColumn(
                name: "MedicineId",
                table: "DailyDetection");

            migrationBuilder.DropColumn(
                name: "RadiologyId",
                table: "DailyDetection");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "DailyDetection");

            migrationBuilder.DropColumn(
                name: "SurgeryId",
                table: "DailyDetection");

            migrationBuilder.DropColumn(
                name: "TreatmentId",
                table: "DailyDetection");

            migrationBuilder.AddColumn<int>(
                name: "DailyDetectionId",
                table: "Treatment",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DailyDetectionId",
                table: "PatientSurgery",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DailyDetectionId",
                table: "PatientRoom",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DailyDetectionId",
                table: "PatientRediology",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DailyDetectionId",
                table: "PatientMedicine",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DailyDetectionId",
                table: "PatientLab",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_DailyDetectionId",
                table: "Treatment",
                column: "DailyDetectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientSurgery_DailyDetectionId",
                table: "PatientSurgery",
                column: "DailyDetectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientRoom_DailyDetectionId",
                table: "PatientRoom",
                column: "DailyDetectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientRediology_DailyDetectionId",
                table: "PatientRediology",
                column: "DailyDetectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicine_DailyDetectionId",
                table: "PatientMedicine",
                column: "DailyDetectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientLab_DailyDetectionId",
                table: "PatientLab",
                column: "DailyDetectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientLab_DailyDetection_DailyDetectionId",
                table: "PatientLab",
                column: "DailyDetectionId",
                principalTable: "DailyDetection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMedicine_DailyDetection_DailyDetectionId",
                table: "PatientMedicine",
                column: "DailyDetectionId",
                principalTable: "DailyDetection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientRediology_DailyDetection_DailyDetectionId",
                table: "PatientRediology",
                column: "DailyDetectionId",
                principalTable: "DailyDetection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientRoom_DailyDetection_DailyDetectionId",
                table: "PatientRoom",
                column: "DailyDetectionId",
                principalTable: "DailyDetection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientSurgery_DailyDetection_DailyDetectionId",
                table: "PatientSurgery",
                column: "DailyDetectionId",
                principalTable: "DailyDetection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Treatment_DailyDetection_DailyDetectionId",
                table: "Treatment",
                column: "DailyDetectionId",
                principalTable: "DailyDetection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientLab_DailyDetection_DailyDetectionId",
                table: "PatientLab");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientMedicine_DailyDetection_DailyDetectionId",
                table: "PatientMedicine");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientRediology_DailyDetection_DailyDetectionId",
                table: "PatientRediology");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientRoom_DailyDetection_DailyDetectionId",
                table: "PatientRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientSurgery_DailyDetection_DailyDetectionId",
                table: "PatientSurgery");

            migrationBuilder.DropForeignKey(
                name: "FK_Treatment_DailyDetection_DailyDetectionId",
                table: "Treatment");

            migrationBuilder.DropIndex(
                name: "IX_Treatment_DailyDetectionId",
                table: "Treatment");

            migrationBuilder.DropIndex(
                name: "IX_PatientSurgery_DailyDetectionId",
                table: "PatientSurgery");

            migrationBuilder.DropIndex(
                name: "IX_PatientRoom_DailyDetectionId",
                table: "PatientRoom");

            migrationBuilder.DropIndex(
                name: "IX_PatientRediology_DailyDetectionId",
                table: "PatientRediology");

            migrationBuilder.DropIndex(
                name: "IX_PatientMedicine_DailyDetectionId",
                table: "PatientMedicine");

            migrationBuilder.DropIndex(
                name: "IX_PatientLab_DailyDetectionId",
                table: "PatientLab");

            migrationBuilder.DropColumn(
                name: "DailyDetectionId",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "DailyDetectionId",
                table: "PatientSurgery");

            migrationBuilder.DropColumn(
                name: "DailyDetectionId",
                table: "PatientRoom");

            migrationBuilder.DropColumn(
                name: "DailyDetectionId",
                table: "PatientRediology");

            migrationBuilder.DropColumn(
                name: "DailyDetectionId",
                table: "PatientMedicine");

            migrationBuilder.DropColumn(
                name: "DailyDetectionId",
                table: "PatientLab");

            migrationBuilder.AddColumn<int>(
                name: "LabId",
                table: "DailyDetection",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedicineId",
                table: "DailyDetection",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RadiologyId",
                table: "DailyDetection",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "DailyDetection",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SurgeryId",
                table: "DailyDetection",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TreatmentId",
                table: "DailyDetection",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DailyDetection_LabId",
                table: "DailyDetection",
                column: "LabId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyDetection_MedicineId",
                table: "DailyDetection",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyDetection_RadiologyId",
                table: "DailyDetection",
                column: "RadiologyId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyDetection_RoomId",
                table: "DailyDetection",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyDetection_SurgeryId",
                table: "DailyDetection",
                column: "SurgeryId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyDetection_TreatmentId",
                table: "DailyDetection",
                column: "TreatmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyDetection_Lab_LabId",
                table: "DailyDetection",
                column: "LabId",
                principalTable: "Lab",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyDetection_Medicine_MedicineId",
                table: "DailyDetection",
                column: "MedicineId",
                principalTable: "Medicine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyDetection_Radiology_RadiologyId",
                table: "DailyDetection",
                column: "RadiologyId",
                principalTable: "Radiology",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyDetection_Room_RoomId",
                table: "DailyDetection",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyDetection_Surgery_SurgeryId",
                table: "DailyDetection",
                column: "SurgeryId",
                principalTable: "Surgery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyDetection_Treatment_TreatmentId",
                table: "DailyDetection",
                column: "TreatmentId",
                principalTable: "Treatment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
