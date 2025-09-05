-- ================================
-- Database: HealthcareBooking
-- ================================
CREATE DATABASE HealthcareBooking;
GO
USE HealthcareBooking;
GO

-- ================================
-- Users Table
-- ================================
CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(150) UNIQUE NOT NULL,
    PasswordHash NVARCHAR(200) NOT NULL,
    Role NVARCHAR(20) CHECK (Role IN ('Patient','Doctor','Admin')) NOT NULL,
    Phone NVARCHAR(15),
    Address NVARCHAR(200)
);

-- ================================
-- Doctors Table
-- ================================
CREATE TABLE Doctors (
    DoctorId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    Specialization NVARCHAR(100) NOT NULL,
    Qualification NVARCHAR(100),
    ExperienceYears INT,
    ConsultationFee DECIMAL(10,2),
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

-- ================================
-- Doctor Availability
-- ================================
CREATE TABLE DoctorAvailability (
    AvailabilityId INT IDENTITY(1,1) PRIMARY KEY,
    DoctorId INT NOT NULL,
    DayOfWeek NVARCHAR(20) NOT NULL,
    StartTime TIME NOT NULL,
    EndTime TIME NOT NULL,
    IsAvailable BIT DEFAULT 1,
    FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId)
);

-- ================================
-- Appointments
-- ================================
CREATE TABLE Appointments (
    AppointmentId INT IDENTITY(1,1) PRIMARY KEY,
    PatientId INT NOT NULL,
    DoctorId INT NOT NULL,
    AppointmentDate DATE NOT NULL,
    SlotTime TIME NOT NULL,
    Status NVARCHAR(20) CHECK (Status IN ('Pending','Confirmed','Completed','Cancelled')) NOT NULL,
    PaymentStatus NVARCHAR(20) CHECK (PaymentStatus IN ('Pending','Paid','Refunded')) NOT NULL,
    FOREIGN KEY (PatientId) REFERENCES Users(UserId),
    FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId)
);

-- ================================
-- Medical Records
-- ================================
CREATE TABLE MedicalRecords (
    RecordId INT IDENTITY(1,1) PRIMARY KEY,
    PatientId INT NOT NULL,
    DoctorId INT NOT NULL,
    AppointmentId INT NOT NULL,
    Diagnosis NVARCHAR(500),
    Prescription NVARCHAR(500),
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (PatientId) REFERENCES Users(UserId),
    FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId),
    FOREIGN KEY (AppointmentId) REFERENCES Appointments(AppointmentId)
);

-- ================================
-- Payments
-- ================================
CREATE TABLE Payments (
    PaymentId INT IDENTITY(1,1) PRIMARY KEY,
    AppointmentId INT NOT NULL,
    Amount DECIMAL(10,2) NOT NULL,
    PaymentMethod NVARCHAR(50) NOT NULL,
    TransactionDate DATETIME NOT NULL DEFAULT GETDATE(),
    Status NVARCHAR(20) CHECK (Status IN ('Success','Failed','Refunded')) NOT NULL,
    FOREIGN KEY (AppointmentId) REFERENCES Appointments(AppointmentId)
);

-- ================================
-- Insert Sample Data
-- ================================

-- Users
INSERT INTO Users (Name, Email, PasswordHash, Role, Phone, Address)
VALUES
('Alice Johnson', 'alice@example.com', 'hash1', 'Patient', '9876543210', 'Hyderabad'),
('Dr. Robert Smith', 'drsmith@example.com', 'hash2', 'Doctor', '9123456780', 'Chennai'),
('Admin User', 'admin@example.com', 'hash3', 'Admin', '9000000000', 'Bangalore');

-- Doctors
INSERT INTO Doctors (UserId, Specialization, Qualification, ExperienceYears, ConsultationFee)
VALUES
(2, 'Cardiologist', 'MD Cardiology', 12, 1500.00);

-- Doctor Availability
INSERT INTO DoctorAvailability (DoctorId, DayOfWeek, StartTime, EndTime, IsAvailable)
VALUES
(1, 'Monday', '10:00', '13:00', 1),
(1, 'Wednesday', '14:00', '18:00', 1);

-- Appointments
INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, SlotTime, Status, PaymentStatus)
VALUES
(1, 1, '2025-09-05', '10:30', 'Confirmed', 'Paid');

-- Medical Records
INSERT INTO MedicalRecords (PatientId, DoctorId, AppointmentId, Diagnosis, Prescription)
VALUES
(1, 1, 1, 'Hypertension', 'Medicine A 5mg daily');

-- Payments
INSERT INTO Payments (AppointmentId, Amount, PaymentMethod, Status)
VALUES
(1, 1500.00, 'UPI', 'Success');

-- ================================
-- Check Data
-- ================================
SELECT * FROM Users;
SELECT * FROM Doctors;
SELECT * FROM DoctorAvailability;
SELECT * FROM Appointments;
SELECT * FROM MedicalRecords;
SELECT * FROM Payments;
