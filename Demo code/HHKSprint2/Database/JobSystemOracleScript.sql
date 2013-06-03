DROP TABLE FDMUser CASCADE CONSTRAINTS;
DROP TABLE Stream CASCADE CONSTRAINTS;
DROP TABLE Profile CASCADE CONSTRAINTS;
DROP TABLE Sessions CASCADE CONSTRAINTS;
DROP SEQUENCE session_id_seq;
DROP SEQUENCE user_id_seq;
DROP TABLE Type CASCADE CONSTRAINTS;
DROP SEQUENCE Profile_id_seq;
DROP TABLE Comments CASCADE CONSTRAINTS;
DROP SEQUENCE comment_id_seq;
DROP TABLE JobPost CASCADE CONSTRAINTS;
DROP SEQUENCE job_id_seq;
DROP TABLE Favourite CASCADE CONSTRAINTS;
DROP SEQUENCE favourite_id_seq;
DROP TABLE UserSkill CASCADE CONSTRAINTS;
DROP SEQUENCE userSkill_id_seq;
DROP TABLE Skill CASCADE CONSTRAINTS;
DROP SEQUENCE skill_id_seq;
DROP TABLE JobSkill CASCADE CONSTRAINTS;
DROP SEQUENCE jobSkill_id_seq;
DROP TABLE Status CASCADE CONSTRAINTS;
DROP TABLE Trainee_Status CASCADE CONSTRAINTS;
DROP TABLE Recommendations CASCADE CONSTRAINTS;
DROP SEQUENCE recommendation_id_seq;

PURGE RECYCLEBIN;

CREATE TABLE Stream (
  Stream_id      NUMBER(6),
  StreamText     VARCHAR2(25),
  CONSTRAINT stream_pk PRIMARY KEY (Stream_id)
);

CREATE TABLE Status(
  Status_id 		NUMBER(6),
  StatusText		VARCHAR2(20),
  CONSTRAINT status_pk PRIMARY KEY (Status_id)
)
;

CREATE TABLE Trainee_Status(
  TStatus_id 		NUMBER(6),
  TStatusText		VARCHAR2(20),
  CONSTRAINT t_status_pk PRIMARY KEY (TStatus_id)
)
;

CREATE TABLE Type(
  Type_id 		NUMBER(6),
  Type_Text		VARCHAR2(20),
  CONSTRAINT type_pk PRIMARY KEY (Type_id)
)
;

CREATE TABLE FDMUser (
  User_id			Number(6),
    Type_id			NUMBER(6),
  Username			VARCHAR2(20),
  Password			VARCHAR2(20),
  FirstName			VARCHAR2(20),
  LastName			VARCHAR2(20),
  Email   			VARCHAR2(100), 
  Location      VARCHAR2(250),
  CONSTRAINT user_pk PRIMARY KEY (User_id),
  CONSTRAINT u_typeId_fk FOREIGN KEY (Type_id) REFERENCES Type(Type_id)
);

CREATE SEQUENCE user_id_seq
  INCREMENT BY 1
  START WITH 1
;

CREATE TABLE Profile (
  Profile_id      NUMBER(6),
  User_id          NUMBER(6),
  Stream_id         NUMBER(6),
  TStatus_id 		NUMBER(6),
  Degree         VARCHAR2(50),
  Modules          VARCHAR(500),  
  CONSTRAINT property_pk PRIMARY KEY (Profile_id),
  CONSTRAINT p_userId_fk FOREIGN KEY (User_id) REFERENCES FDMUser(User_id),  
  CONSTRAINT p_streamId_fk FOREIGN KEY (Stream_id) REFERENCES Stream(Stream_id),
  CONSTRAINT p_tStatusId_fk FOREIGN KEY (TStatus_id) REFERENCES Trainee_Status(TStatus_id)
);

CREATE SEQUENCE profile_id_seq
  INCREMENT BY 1
  START WITH 1
;

CREATE TABLE JobPost (
  Job_id       NUMBER(6),
  User_id      NUMBER(6),
  Stream_id     NUMBER(6),
  Status_id     NUMBER(6),
  Description   VARCHAR(1000),
  Title          VARCHAR2(50),
  DatePosted      Date,
  Deadline        Date,
  Company         VARCHAR2(500),
  Location        VARCHAR2(500),
  CONSTRAINT job_pk PRIMARY KEY (Job_id),
  CONSTRAINT j_userId_fk FOREIGN KEY (User_id) REFERENCES FDMUser(User_id),  
  CONSTRAINT j_streamId_fk FOREIGN KEY (Stream_id) REFERENCES Stream(Stream_id),
  CONSTRAINT j_statusId_fk FOREIGN KEY (Status_id) REFERENCES Status(Status_id)
);

CREATE SEQUENCE job_id_seq
  INCREMENT BY 1
  START WITH 1
;

CREATE TABLE Comments (
  Comment_id        NUMBER(6),
  User_id       	   NUMBER(6),
  Job_id           NUMBER(6),
  Text            VARCHAR2(1000),
  DateAdded            Date,
  CONSTRAINT comment_pk PRIMARY KEY (Comment_id),
  CONSTRAINT c_userId_fk FOREIGN KEY (User_id) REFERENCES FDMUser(User_id),
  CONSTRAINT c_jobId_fk FOREIGN KEY (Job_id) REFERENCES JobPost(Job_id)
);

CREATE SEQUENCE comment_id_seq
  INCREMENT BY 1
  START WITH 1
;

CREATE TABLE Sessions (
  Session_id   NUMBER(6),
  Session_Guid VARCHAR2(36),
  User_id       	NUMBER(6),
  Type_id		NUMBER(6),
  CONSTRAINT session_pk PRIMARY KEY (Session_id),
  CONSTRAINT s_userId_fk FOREIGN KEY (User_id) REFERENCES FDMUser(User_id),
  CONSTRAINT s_TypeId_fk FOREIGN KEY (Type_id) REFERENCES Type(Type_id)
);


CREATE SEQUENCE session_id_seq
  INCREMENT BY 1
  START WITH 1
;

CREATE TABLE Skill (
  Skill_id	NUMBER(6),
  SkillText			VARCHAR2(500),
  CONSTRAINT skill_pk PRIMARY KEY (Skill_id)
)
;

CREATE SEQUENCE skill_id_seq
  INCREMENT BY 1
  START WITH 1
;

CREATE TABLE UserSkill (
  UserSkill_id        NUMBER(6),
  User_id         NUMBER(6),
  Skill_id      NUMBER(6),
  CONSTRAINT us_pk PRIMARY KEY (UserSkill_id),
  CONSTRAINT us_user_fk FOREIGN KEY (User_id) REFERENCES FDMUser(User_id),
  CONSTRAINT us_skill_fk FOREIGN KEY (Skill_id) REFERENCES Skill(Skill_id)
);

CREATE SEQUENCE userSkill_id_seq
  INCREMENT BY 1
  START WITH 1
;

CREATE TABLE Favourite (
  Fav_id          NUMBER(6),
  User_id            NUMBER(6),
  Job_id        NUMBER(6),
  CONSTRAINT fav_pk PRIMARY KEY (Fav_id),
  CONSTRAINT fav_user_fk FOREIGN KEY (User_id) REFERENCES FDMUser(User_id),
  CONSTRAINT fav_job_fk FOREIGN KEY (Job_id) REFERENCES JobPost(Job_id)
);

CREATE SEQUENCE favourite_id_seq
  INCREMENT BY 1
  START WITH 1
;

CREATE TABLE JobSkill(
  JobSkill_id		NUMBER(6),
  Job_id			NUMBER(6),
  Skill_id		NUMBER(6),
  CONSTRAINT js_pk PRIMARY KEY (JobSkill_id),
  CONSTRAINT js_job_fk FOREIGN KEY (Job_id) REFERENCES JobPost(Job_id),
  CONSTRAINT js_skill_fk FOREIGN KEY (Skill_id) REFERENCES Skill(Skill_id)
)
;

CREATE SEQUENCE jobskill_id_seq
  INCREMENT BY 1
  START WITH 1
;

CREATE TABLE Recommendations(
  Recommendation_id		NUMBER(6),
  Job_id			NUMBER(6),
  Recomender_id		NUMBER(6),
  Recomendee_id		NUMBER(6),
  Reason          VARCHAR(1000),
  CONSTRAINT rec_pk PRIMARY KEY (Recommendation_id),
  CONSTRAINT rec_job_fk FOREIGN KEY (Job_id) REFERENCES JobPost(Job_id),
  CONSTRAINT rec_recommender_fk FOREIGN KEY (Recomender_id) REFERENCES FDMUSER(User_id),
  CONSTRAINT rec_recommendee_fk FOREIGN KEY (Recomendee_id) REFERENCES FDMUSER(User_id)
);

CREATE SEQUENCE recommendation_id_seq
INCREMENT BY 1
  START WITH 1
;

INSERT INTO Status (Status_id, StatusText) VALUES (1,'Potential');
INSERT INTO Status (Status_id, StatusText) VALUES (2,'Open');
INSERT INTO Status (Status_id, StatusText) VALUES (3,'Interviewing');
INSERT INTO Status (Status_id, StatusText) VALUES (4,'On Hold');
INSERT INTO Status (Status_id, StatusText) VALUES (5,'Filled');

INSERT INTO Trainee_Status (TStatus_id, TStatusText) VALUES (1,'Training');
INSERT INTO Trainee_Status (TStatus_id, TStatusText) VALUES (2,'Placed');
INSERT INTO Trainee_Status (TStatus_id, TStatusText) VALUES (3,'Available');

INSERT INTO Type (Type_id, Type_Text) VALUES (1,'Account Manager');
INSERT INTO Type (Type_id, Type_Text) VALUES (2,'Consultant');
INSERT INTO Type (Type_id, Type_Text) VALUES (3,'Administrator');
INSERT INTO Type (Type_id, Type_Text) VALUES (4,'Trainer');

INSERT INTO Stream (Stream_id, StreamText) VALUES (1,'Java');
INSERT INTO Stream (Stream_id, StreamText) VALUES (2,'Dot Net');
INSERT INTO Stream (Stream_id, StreamText) VALUES (3,'Testing');
INSERT INTO Stream (Stream_id, StreamText) VALUES (4,'Application Support');
INSERT INTO Stream (Stream_id, StreamText) VALUES (5,'Project Management Office');
INSERT INTO Stream (Stream_id, StreamText) VALUES (6,'Infrastructure');
INSERT INTO Stream (Stream_id, StreamText) VALUES (7,'All');

INSERT INTO Skill (Skill_id, SkillText) VALUES (skill_id_seq.nextval,'.Net');
INSERT INTO Skill (Skill_id, SkillText) VALUES (skill_id_seq.nextval,'Prince2 Professional');
INSERT INTO Skill (Skill_id, SkillText) VALUES (skill_id_seq.nextval,'Java');
INSERT INTO Skill (Skill_id, SkillText) VALUES (skill_id_seq.nextval,'Unix');
INSERT INTO Skill (Skill_id, SkillText) VALUES (skill_id_seq.nextval,'SQL');
INSERT INTO Skill (Skill_id, SkillText) VALUES (skill_id_seq.nextval,'Selenium IDE');
INSERT INTO Skill (Skill_id, SkillText) VALUES (skill_id_seq.nextval,'VMware');
INSERT INTO Skill (Skill_id, SkillText) VALUES (skill_id_seq.nextval,'Active Directory');
INSERT INTO Skill (Skill_id, SkillText) VALUES (skill_id_seq.nextval,'QuickTest Professional');
INSERT INTO Skill (Skill_id, SkillText) VALUES (skill_id_seq.nextval,'Professional Skills');
INSERT INTO Skill (Skill_id, SkillText) VALUES (skill_id_seq.nextval,'Excel VBA');
INSERT INTO Skill (Skill_id, SkillText) VALUES (skill_id_seq.nextval,'ISEB Business Analysis');
INSERT INTO Skill (Skill_id, SkillText) VALUES (skill_id_seq.nextval,'ITIL Foundation v3');
INSERT INTO Skill (Skill_id, SkillText) VALUES (skill_id_seq.nextval,'IOC');
INSERT INTO Skill (Skill_id, SkillText) VALUES (skill_id_seq.nextval,'JDBC');
INSERT INTO Skill (Skill_id, SkillText) VALUES (skill_id_seq.nextval,'Spring');
INSERT INTO Skill (Skill_id, SkillText) VALUES (skill_id_seq.nextval,'WPF');
INSERT INTO Skill (Skill_id, SkillText) VALUES (skill_id_seq.nextval,'WCF');
INSERT INTO Skill (Skill_id, SkillText) VALUES (skill_id_seq.nextval,'ADO.Net');


INSERT INTO FDMUser (User_id, Username, Password, FirstName, LastName, Email, Type_id, Location) VALUES (user_id_seq.nextval, 'katie.hodgkiss', 'password', 'Katie', 'Hodgkiss', 'katie.hodgkiss@fdmgroup.com', 2, 'London');
INSERT INTO FDMUser (User_id, Username, Password, FirstName, LastName, Email, Type_id, Location) VALUES (user_id_seq.nextval, 'hannah.williams', 'password', 'Hannah', 'Williams', 'hannah.williams@fdmgroup.com', 4, 'Wales');
INSERT INTO FDMUser (User_id, Username, Password, FirstName, LastName, Email, Type_id, Location) VALUES (user_id_seq.nextval, 'hinnah.sarwar', 'password', 'Hinnah', 'Sarwar', 'hinnah.sarwar@fdmgroup.com', 2, 'Manchester');
INSERT INTO FDMUser (User_id, Username, Password, FirstName, LastName, Email, Type_id, Location) VALUES (user_id_seq.nextval, 'kimberley.jackson', 'password', 'Kimberley', 'Jackson', 'kimberley.jackson@fdmgroup.com', 1, 'Leeds');
INSERT INTO FDMUser (User_id, Username, Password, FirstName, LastName, Email, Type_id, Location) VALUES (user_id_seq.nextval, 'richard.mullock', 'password', 'Richard', 'Mullock', 'richard.mullock@fdmgroup.com', 4, 'Sheffield');
INSERT INTO FDMUser (User_id, Username, Password, FirstName, LastName, Email, Type_id, Location) VALUES (user_id_seq.nextval, 'roxanne.cuddy', 'password', 'Roxanne', 'Cuddy', 'roxanne.cuddy@fdmgroup.com', 1, 'Manchester');
INSERT INTO FDMUser (User_id, Username, Password, FirstName, LastName, Email, Type_id, Location) VALUES (user_id_seq.nextval, 'ben.green', 'password', 'Ben', 'Green', 'ben.green@fdmgroup.com', 2, 'Sheffield');
INSERT INTO FDMUser (User_id, Username, Password, FirstName, LastName, Email, Type_id, Location) VALUES (user_id_seq.nextval, 'sarah.smith', 'password', 'Sarah', 'Smith', 'sarah.smith@fdmgroup.com', 3, 'Manchester');
INSERT INTO FDMUser (User_id, Username, Password, FirstName, LastName, Email, Type_id, Location) VALUES (user_id_seq.nextval, 'rupert.pearce', 'password', 'Rupert', 'Pearce', 'rupert.pearce@fdmgroup.com', 1, 'Brighton');
INSERT INTO FDMUser (User_id, Username, Password, FirstName, LastName, Email, Type_id, Location) VALUES (user_id_seq.nextval, 'jonathan.peace', 'password', 'Jonathan', 'Peace', 'jonathan.peace@fdmgroup.com', 2, 'Warwick');
INSERT INTO FDMUser (User_id, Username, Password, FirstName, LastName, Email, Type_id, Location) VALUES (user_id_seq.nextval, 'richard.stott', 'password', 'Richard', 'Stott', 'richard.scott@fdmgroup.com', 2, 'Bradford');
INSERT INTO FDMUser (User_id, Username, Password, FirstName, LastName, Email, Type_id, Location) VALUES (user_id_seq.nextval, 'si.peng', 'password', 'Si', 'Peng', 'si.peng@fdmgroup.com', 2, 'Hongkong');

INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,1, 1);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,4, 2);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,7, 3);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,1, 4);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,1, 5);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,10, 6);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,2, 7);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,3, 8);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,10, 9);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,2, 10);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,3, 10);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,4, 10);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,1, 10);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,7, 10);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,11, 10);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,10, 10);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,12, 10);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,4, 11);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,4, 12);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,3, 13);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,3, 14);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,7, 15);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,7, 16);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,1, 17);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,1, 18);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,1, 19);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,12, 2);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,12, 11);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,12, 12);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,11, 6);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,11, 9);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,2, 4);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,3, 4);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,4, 4);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,7, 4);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,11, 4);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,10, 4);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,12, 4);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,2, 5);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,3, 5);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,4, 5);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,7, 5);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,10, 5);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,11, 5);
INSERT INTO UserSkill (UserSkill_id, User_id, Skill_id) VALUES (userSkill_id_seq.nextval,12, 5);


INSERT INTO JobPost (Job_id, User_id, Stream_id, Status_id, Description, Title, DatePosted, Deadline, Company, Location) VALUES (job_id_seq.nextval, 6, 2, 1, 'Will be responsible for PC based applications written in C#.Net4. This team is based in Luton and its key area is Sensor Systems. You will be joining a team of aroun 80 developers, however on projects you will normally be working in teams of 7 developers and 3 managers.', 'Dot Net Developer', SYSDATE, SYSDATE +14, 'RBI', 'Surrey');   
INSERT INTO JobPost (Job_id, User_id, Stream_id, Status_id, Description, Title, DatePosted, Deadline, Company, Location) VALUES (job_id_seq.nextval, 9, 1, 2, 'We take great stock in what the term “developer” actually means. All our existing programmers do the things they do to progress the product they’re working on, rather than slogging away with no end in sight. We have internal hack days to work on stuff just for fun: we have time assigned to work on pet projects or learning exercises so that you don’t go stale.', 'Java Developer', SYSDATE - 2, SYSDATE +12, 'YBS', 'Bradford');
INSERT INTO JobPost (Job_id, User_id, Stream_id, Status_id, Description, Title, DatePosted, Deadline, Company, Location) VALUES (job_id_seq.nextval, 6, 3, 3, 'If you like to break things and find faults in the software. you can also replicate the problem then surely you will enjoy working with us.', 'Performance Tester', SYSDATE -14, SYSDATE +14, 'Barclays', 'Knutsford');
INSERT INTO JobPost (Job_id, User_id, Stream_id, Status_id, Description, Title, DatePosted, Deadline, Company, Location) VALUES (job_id_seq.nextval, 9, 4, 4, 'Selex are building a team of what they call double depth employee’s, these are business focused guys with technical no how, you will have the ability to talk to the business and action technical requirements.They have started using a rapid deployment application platform called Mendix which enables companies to build, integrate and deploy web and mobile applications really fast. It is code free and completely agile and allows you to build functional applications within days not weeks. ', 'Application Support', SYSDATE -30, SYSDATE +14, 'Selex Galileo', 'Luton');
INSERT INTO JobPost (Job_id, User_id, Stream_id, Status_id, Description, Title, DatePosted, Deadline, Company, Location) VALUES (job_id_seq.nextval, 6, 7, 2, 'SQL Dev will be responsible for creating and managing the database. Knowledge and experience of SQL is the main requirement. You will also be required to write the stored procedures to improve the efficiency hence familarity with PL/SQL will also be essential', 'Database Analyst', SYSDATE, SYSDATE +13, 'Asda', 'Leeds');

INSERT INTO JobSkill (JobSkill_id, Job_id, Skill_id) VALUES (jobSkill_id_seq.nextval,1, 1);
INSERT INTO JobSkill (JobSkill_id, Job_id, Skill_id) VALUES (jobSkill_id_seq.nextval,1, 17);
INSERT INTO JobSkill (JobSkill_id, Job_id, Skill_id) VALUES (jobSkill_id_seq.nextval,1, 18);
INSERT INTO JobSkill (JobSkill_id, Job_id, Skill_id) VALUES (jobSkill_id_seq.nextval,2, 3);
INSERT INTO JobSkill (JobSkill_id, Job_id, Skill_id) VALUES (jobSkill_id_seq.nextval,2, 15);
INSERT INTO JobSkill (JobSkill_id, Job_id, Skill_id) VALUES (jobSkill_id_seq.nextval,2, 16);
INSERT INTO JobSkill (JobSkill_id, Job_id, Skill_id) VALUES (jobSkill_id_seq.nextval,3, 9);
INSERT INTO JobSkill (JobSkill_id, Job_id, Skill_id) VALUES (jobSkill_id_seq.nextval,3, 6);
INSERT INTO JobSkill (JobSkill_id, Job_id, Skill_id) VALUES (jobSkill_id_seq.nextval,4, 13);
INSERT INTO JobSkill (JobSkill_id, Job_id, Skill_id) VALUES (jobSkill_id_seq.nextval,4, 14);
INSERT INTO JobSkill (JobSkill_id, Job_id, Skill_id) VALUES (jobSkill_id_seq.nextval,5, 5);

INSERT INTO Profile (Profile_id, User_id, Stream_id, TStatus_id, Degree, Modules) VALUES (profile_id_seq.nextval, 1, 2, 1,'Computer Science', 'Introduction to programming');
INSERT INTO Profile (Profile_id, User_id, Stream_id, TStatus_id, Degree, Modules) VALUES (profile_id_seq.nextval, 2, 6, 2,'IT and Multimedia Computing', 'Introduction to infrastructure');
INSERT INTO Profile (Profile_id, User_id, Stream_id, TStatus_id, Degree, Modules) VALUES (profile_id_seq.nextval, 3, 4, 3,'Computer Science', 'Introduction to app support');
INSERT INTO Profile (Profile_id, User_id, Stream_id, TStatus_id, Degree, Modules) VALUES (profile_id_seq.nextval, 4, 5, 1,'Artificial Intelligence', 'Introduction to PMO');
INSERT INTO Profile (Profile_id, User_id, Stream_id, TStatus_id, Degree, Modules) VALUES (profile_id_seq.nextval, 7, 1, 2, 'Mathematics', 'Introduction to linear equations');
INSERT INTO Profile (Profile_id, User_id, Stream_id, TStatus_id, Degree, Modules) VALUES (profile_id_seq.nextval, 10, 3, 3, 'Physics', 'Introduction to space and gravity');
INSERT INTO Profile (Profile_id, User_id, Stream_id, TStatus_id, Degree, Modules) VALUES (profile_id_seq.nextval, 11, 3, 1, 'Forensic Computing', 'Introduction to forensics');
INSERT INTO Profile (Profile_id, User_id, Stream_id, TStatus_id, Degree, Modules) VALUES (profile_id_seq.nextval, 12, 5, 2, 'Computer Science', 'Introduction to management');

create or replace
Procedure sp_add_user( type_id IN NUMBER, username IN VARCHAR2, password IN VARCHAR2, firstname IN VARCHAR2,
            lastname IN VARCHAR2, email IN VARCHAR2, location IN VARCHAR2, stream_id IN NUMBER) AS
BEGIN

     DECLARE 
      rowNotAdded EXCEPTION;         
    BEGIN
      INSERT INTO FDMUSER (User_id, type_id, username, password, firstname, lastname, email, Location)
      VALUES (user_id_seq.nextval, type_id, username, password, firstname, lastname, email, location);
      
      IF SQL%ROWCOUNT = 0 THEN 
        RAISE rowNotAdded;
      ELSIF  type_id = 2 THEN
        sp_add_profile(stream_id);
      END IF;
      
      EXCEPTION
        WHEN rowNotAdded THEN
              ROLLBACK;   
    END;
END sp_add_user
;
/

CREATE OR REPLACE PROCEDURE sp_add_profile(stream_id IN NUMBER)
AS

BEGIN
  DECLARE 
    rowNotAdded EXCEPTION;     
  BEGIN 
    INSERT INTO Profile (profile_id, user_id, stream_id, tstatus_id)
    VALUES (profile_id_seq.nextval, user_id_seq.currval, stream_id, 1);

    IF SQL%ROWCOUNT = 0 THEN 
      RAISE rowNotAdded;
    ELSE
      COMMIT;
    END IF;
    
    EXCEPTION
      WHEN rowNotAdded THEN
        ROLLBACK;  
        
   END; 
END sp_add_profile
;
/

CREATE OR REPLACE Procedure sp_add_skill(skilltxt IN VARCHAR2) AS
BEGIN
    INSERT INTO Skill (skill_id, skilltext) VALUES ( skill_id_seq.nextval, skilltxt);     
END sp_add_skill
;
/

CREATE OR REPLACE Procedure sp_add_job( user_id IN NUMBER, stream_id IN NUMBER, status_id IN NUMBER, description IN VARCHAR2,
                                        title IN VARCHAR2, deadline IN DATE, company IN VARCHAR2, location IN VARCHAR2) AS
BEGIN

     DECLARE 
      rowNotAdded EXCEPTION;         
    BEGIN
      INSERT INTO JobPost (Job_id, User_id, Stream_id, Status_id, Description, Title, DatePosted, Deadline, Company, Location)
      VALUES (job_id_seq.nextval, user_id, stream_id, status_id, description, title, SYSDATE, deadline, company, location);
      
      IF SQL%ROWCOUNT = 0 THEN 
        RAISE rowNotAdded;
      END IF;
      
      EXCEPTION
        WHEN rowNotAdded THEN
              ROLLBACK;   
    END;
END sp_add_job
;
/


CREATE OR REPLACE PROCEDURE sp_add_jobSkill( skill_id IN NUMBER)
AS

BEGIN
  DECLARE 
    rowNotAdded EXCEPTION;     
  BEGIN 
    INSERT INTO JobSkill (JobSkill_id, job_id, skill_id)
    VALUES (jobskill_id_seq.nextval, job_id_seq.currval, skill_id);

    IF SQL%ROWCOUNT = 0 THEN 
      RAISE rowNotAdded;
    ELSE
      COMMIT;
    END IF;
    
    EXCEPTION
      WHEN rowNotAdded THEN
        ROLLBACK;  
        
   END; 
END sp_add_jobSkill
;
/

CREATE OR REPLACE Procedure sp_del_profile(userId IN NUMBER) AS
BEGIN
    DELETE FROM profile WHERE profile.user_id = userId;
END sp_del_profile
;
/

CREATE OR REPLACE Procedure sp_del_userskill_with_userId(userId IN NUMBER) AS
BEGIN
    DELETE FROM USERSKILL WHERE USERSKILL.user_id = userId;
END sp_del_userskill_with_userId
;
/



CREATE OR REPLACE PROCEDURE sp_del_sessions(userId IN NUMBER)
AS

BEGIN 
    DELETE FROM SESSIONS WHERE SESSIONS.user_id = userId; 
END sp_del_sessions
;
/

CREATE OR REPLACE Procedure sp_del_user(userId IN NUMBER) AS
BEGIN

     DECLARE 
      rowNotDeleted EXCEPTION;         
    BEGIN
      DELETE FROM FDMUSER  WHERE fdmuser.user_id = userId;
      
      IF SQL%ROWCOUNT = 0 THEN 
        RAISE rowNotDeleted;
      ELSE
        COMMIT;
      END IF;
      
      EXCEPTION
        WHEN rowNotDeleted THEN
              ROLLBACK;   
    END;
END sp_del_user
;
/



CREATE OR REPLACE Procedure sp_del_user_and_constraints(userId IN NUMBER) AS
BEGIN
DECLARE 
      rowNotDeleted EXCEPTION;
      BEGIN
        sp_del_profile(userId);
        sp_del_userskill_with_userId(userId);
        sp_del_sessions(userId);
        sp_del_user(userId);
        DELETE FROM COMMENTS WHERE COMMENTS.user_id = userId;
        DELETE FROM RECOMMENDATIONS WHERE recommendations.recomendee_id = userId OR recommendations.recomender_id = userId;
        DELETE FROM FAVOURITE WHERE FAVOURITE.user_id = userID;
        
      IF SQL%ROWCOUNT = 0 THEN 
      RAISE rowNotDeleted;
      ELSE
        COMMIT;
      END IF;
      
      EXCEPTION
        WHEN rowNotDeleted THEN
              ROLLBACK;   
    END;
END sp_del_user_and_constraints
;
/

CREATE OR REPLACE PROCEDURE sp_update_profile( userLocation IN VARCHAR2, userID IN NUMBER, userStream IN NUMBER, tstatID IN NUMBER, userDegree IN VARCHAR2, userModules IN VARCHAR2)
AS

BEGIN
  DECLARE 
    rowNotUpdated EXCEPTION;     
  BEGIN 
    UPDATE FDMUSER SET location = userLocation WHERE user_id = userID;
    UPDATE PROFILE SET stream_id = userStream, tstatus_id = tstatus_id, degree = userdegree, modules = usermodules WHERE user_id = userID;

    IF SQL%ROWCOUNT = 0 THEN 
      RAISE rowNotUpdated;
    ELSE
      COMMIT;
    END IF;
    
    EXCEPTION
      WHEN rowNotUpdated THEN
        ROLLBACK;  
        
   END; 
END sp_update_profile
;
/

CREATE OR REPLACE PROCEDURE sp_add_userSkill( userID IN NUMBER, skill_id IN NUMBER )
AS

BEGIN
  DECLARE 
    rowNotAdded EXCEPTION;     
  BEGIN 
    INSERT INTO UserSkill (UserSkill_id, user_id, skill_id)
    VALUES (userskill_id_seq.nextval, userID, skill_id);

    IF SQL%ROWCOUNT = 0 THEN 
      RAISE rowNotAdded;
    ELSE
      COMMIT;
    END IF;
    
    EXCEPTION
      WHEN rowNotAdded THEN
        ROLLBACK;  
        
   END; 
END sp_add_userSkill
;
/

CREATE OR REPLACE PROCEDURE sp_del_userSkill(userID IN NUMBER, skillID IN NUMBER)
AS
BEGIN 
    DELETE FROM UserSkill WHERE UserSkill.user_id = userID AND UserSkill.skill_id = skillID;
END sp_del_userSkill
;
/

CREATE OR REPLACE PROCEDURE sp_add_comment( user_id IN NUMBER, job_id IN NUMBER, comText IN VARCHAR2)
AS

BEGIN
  DECLARE 
    rowNotAdded EXCEPTION;     
  BEGIN 
    INSERT INTO Comments (comment_id, user_id, job_id, text, dateadded )
    VALUES (comment_id_seq.nextval, user_id, job_id, comText, Sysdate);

    IF SQL%ROWCOUNT = 0 THEN 
      RAISE rowNotAdded;
    ELSE
      COMMIT;
    END IF;
    
    EXCEPTION
      WHEN rowNotAdded THEN
        ROLLBACK;  
        
   END; 
END sp_add_comment
;
/

CREATE OR REPLACE PROCEDURE sp_del_jobskill(jobId in NUMBER, skillId in NUMBER)
AS
BEGIN    
    DELETE FROM JOBSKILL WHERE JOBSKILL.job_id = jobId AND JOBSKILL.skill_id = skillId;
END sp_del_jobskill
;
/

create or replace PROCEDURE sp_update_jobSkill(jobId IN NUMBER, skillId IN NUMBER)
AS   
  BEGIN 
    INSERT INTO JobSkill (JobSkill_id, job_id, skill_id)
    VALUES (jobskill_id_seq.nextval, jobId, skillId); 
END sp_update_jobSkill
;
/

CREATE OR REPLACE PROCEDURE sp_delete_comment( commentId IN NUMBER)
AS

BEGIN
     DELETE FROM COMMENTS WHERE comment_id = commentId;
    COMMIT;    
END sp_delete_comment
;
/


CREATE OR REPLACE PROCEDURE sp_del_job(jobId in NUMBER)
AS
BEGIN    
    DELETE FROM JOBSKILL WHERE JOBSKILL.job_id = jobId;
    DELETE FROM JOBPOST WHERE JOBPOST.job_id = jobId;
    DELETE FROM COMMENTS WHERE COMMENTS.job_id = jobId;
    DELETE FROM FAVOURITE WHERE FAVOURITE.job_id = jobId;
    DELETE FROM RECOMMENDATIONS WHERE RECOMMENDATIONS.job_id = jobId;
END sp_del_job
;
/

CREATE OR REPLACE PROCEDURE sp_add_favourite(userId in NUMBER, jobId in NUMBER)
AS
BEGIN 
    INSERT INTO FAVOURITE(fav_id, user_id, job_id)
    VALUES(FAVOURITE_ID_SEQ.NEXTVAL, userId, jobId);
END sp_add_favourite
;
/

CREATE OR REPLACE PROCEDURE sp_del_favourite(userId in NUMBER, jobId in NUMBER)
AS
BEGIN 
     DELETE FROM FAVOURITE WHERE FAVOURITE.user_id = userId AND FAVOURITE.job_id = jobId;
END sp_del_favourite
;
/

CREATE OR REPLACE PROCEDURE sp_add_recommendation(userId in NUMBER, user_Id IN NUMBER, jobId in NUMBER, reason IN VARCHAR2)
AS
BEGIN 
    INSERT INTO RECOMMENDATIONS(recommendation_id, job_id, recomender_id, recomendee_id, Reason)
    VALUES(RECOMMENDATION_ID_SEQ.NEXTVAL, jobId, userId, user_Id, reason);
END sp_add_recommendation
;
/

CREATE OR REPLACE PROCEDURE sp_delete_recommendation(userId in NUMBER, user_Id IN NUMBER, jobId in NUMBER)
AS
BEGIN 
     DELETE FROM RECOMMENDATIONS WHERE RECOMMENDATIONS.recomender_id = userId AND RECOMMENDATIONS.job_id = jobId AND RECOMMENDATIONS.recomendee_id = user_id;
END sp_delete_recommendation
;
/  

create or replace PROCEDURE sp_update_password(userID IN NUMBER, newPass IN VARCHAR2)
AS   
  BEGIN 
    UPDATE FDMUSER SET FDMUSER.password = newPass WHERE FDMUSER.user_id = userID; 
END sp_update_password
;
/

CREATE OR REPLACE PROCEDURE sp_update_job( jobId IN NUMBER, streamId IN NUMBER, statusId IN NUMBER, descr IN VARCHAR2, jTitle IN VARCHAR2, ddline IN DATE, comp IN VARCHAR2, loc IN VARCHAR2 )
AS

BEGIN
  DECLARE 
    rowNotUpdated EXCEPTION;     
  BEGIN 
    UPDATE JOBPOST SET stream_id = streamId, status_id = statusId, description = descr, Title = jTitle, deadLine = ddline, Company = comp, Location = loc WHERE job_id = jobId;

    IF SQL%ROWCOUNT = 0 THEN 
      RAISE rowNotUpdated;
    ELSE
      COMMIT;
    END IF;
    
    EXCEPTION
      WHEN rowNotUpdated THEN
        ROLLBACK;  
        
   END; 
END sp_update_job
;
/
COMMIT;