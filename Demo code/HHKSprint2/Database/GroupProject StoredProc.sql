CREATE OR REPLACE Procedure sp_add_skill(skilltxt IN VARCHAR2) AS
BEGIN
    INSERT INTO Skill (skill_id, skilltext)
    SELECT skill_id_seq.nextval, skilltxt
    FROM Skill
    WHERE NOT EXISTS (SELECT skilltext FROM skill WHERE skilltext = skilltxt); 
END sp_add_skill
;
/

CREATE OR REPLACE Procedure sp_add_job( user_id IN NUMBER, stream_id IN NUMBER, status_id IN NUMBER, description IN VARCHAR2,
                                        title IN VARCHAR2, deadline IN DATE, company IN VARCHAR2, location IN VARCHAR2, skilltxt IN VARCHAR2) AS
BEGIN

     DECLARE 
      rowNotAdded EXCEPTION;         
    BEGIN
      INSERT INTO JobPost (Job_id, User_id, Stream_id, Status_id, Description, Title, DatePosted, Deadline, Company, Location)
      VALUES (job_id_seq.nextval, user_id, stream_id, status_id, description, title, SYSDATE, deadline, company, location);
      
      IF SQL%ROWCOUNT = 0 THEN 
        RAISE rowNotAdded;
      ELSE
        sp_add_skill(skilltxt);
        sp_add_jobSkill;
      END IF;
      
      EXCEPTION
        WHEN rowNotAdded THEN
              ROLLBACK;   
    END;
END sp_add_job
;
/


CREATE OR REPLACE PROCEDURE sp_add_jobSkill
AS

BEGIN
  DECLARE 
    rowNotAdded EXCEPTION;     
  BEGIN 
    INSERT INTO JobSkill (JobSkill_id, job_id, skill_id)
    VALUES (jobskill_id_seq.nextval, job_id_seq.currval, skill_id_seq.currval);

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