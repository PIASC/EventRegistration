insert into Events (EVENTID,EVENTNAME,EVENTDATE,EVENTVENUE)
            values(1,'Retirement Party',TO_DATE('2017/06/04', 'yyyy/mm/dd'),'Lou House');
            
            select * from EVENTS;
            select * from EVENT_REGISTRATION;
            delete from EVENT_REGISTRATION;
  Update EVENTS set EventName='Bob Lindgren`s Retirement Dinner' where EventID=1;
  
  insert into EVENT_REGISTRATION (REGISTRATIONID,EVENTID,PERSONID,REGISTRATIONDATE,AMOUNTPAID) values(1,3,1,CURRENT_TIMESTAMP,100.00);
  
CREATE SEQUENCE trans_sequence;

CREATE OR REPLACE TRIGGER trans_on_insert
  BEFORE INSERT ON EVENT_TRANSACTIONS
  FOR EACH ROW
BEGIN
  SELECT trans_sequence.nextval
  INTO :new.TransactionID
  FROM dual;
END;


DECLARE 
p_id Number;
BEGIN
Insert into PERSON (PersonID,FIRSTNAME,LASTNAME,EMAIL) values (1,'Harvey','Goodman','hsg@cgc.com') RETURNING PersonID INTO p_id;
 SELECT p_id FROM DUAL;

  END;
select * from PERSON;
delete from PERSON;

select * FROM EVENT_REGISTRATION;

select * from EVENT_TRANSACTIONS where RegistrationID=57;