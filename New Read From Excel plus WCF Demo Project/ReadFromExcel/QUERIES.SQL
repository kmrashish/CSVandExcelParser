--INPUT FIELDS FROM THE USER
--PREFIX TABLE ALIASES BEFORE FIELD NAMES LIKE [[TABLE_ALIAS.FIELD_NAME]]
--CONCATENATE AND MAKE THAT A STRING LIKE [[TABLE_ALIAS.FIELD_NAME], [TABLE_ALIAS.FIELD_NAME], [TABLE_ALIAS.FIELD_NAME]]



select [[TABLE_ALIAS.FIELD_NAME], [TABLE_ALIAS.FIELD_NAME], [TABLE_ALIAS.FIELD_NAME]] from 
ivp_securityMaster_core_securityidentifier iden INNER JOIN ivp_securityMaster_core_referencedata referencedata
on iden.code=ref.code INNER JOIN ivp_securityMaster_securitydetails secdel
on iden.code=secdel.fk_security_id INNER JOIN ivp_securitymaster_securitysummary secsum
on iden.code=secsum.fk_security_id INNER JOIN ivp_securityMaster_risk ris
on iden.code=ris.fk_security_id INNER JOIN ivp_securityMaster_pricingdetails pric
on iden.code=pric.fk_security_id INNER JOIN ivp_securityMaster_dividendhistory divhis
on iden.code=divhis.fk_security_id


--CONVERT THE TABLE TO JSON AND SEND TO THE UI FOR DISPLAY