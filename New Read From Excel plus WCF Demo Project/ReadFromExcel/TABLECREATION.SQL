USE MCA2015;
GO

IF EXISTS(select * from dbo.sysdatabases where name='securityMaster')
drop database securityMaster;
GO

create database securityMaster;
GO

use securityMaster;
go

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'core')
EXEC sys.sp_executesql N'CREATE SCHEMA [core]'
go

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'eq')
EXEC sys.sp_executesql N'CREATE SCHEMA [eq]'
go

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'cb')
EXEC sys.sp_executesql N'CREATE SCHEMA [cb]'
go


IF EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='ivp_securityMaster_core_sectype_id' AND TABLE_SCHEMA='core')
drop table core.ivp_securityMaster_core_sectype_id;
go

create table core.ivp_securityMaster_core_sectype_id(
code bigint primary key identity,
sectype_name nvarchar(100) not null unique,
sectype_description nvarchar(255) not null unique,
created_by nvarchar(50) not null,
created_on date,
last_modified_by date,
last_modified_on date,
);
go

--select * from core.ivp_securityMaster_core_sectype_id

--insert into core.ivp_securityMaster_core_sectype_id values('Equity', 'Equity type', 'Ashish', '06.02.2015', 'Ashish', '06.02.2015')
--insert into core.ivp_securityMaster_core_sectype_id values('Corporate Bond', 'Bond type', 'Ashish', '06.02.2015', 'Ashish', '06.02.2015')


IF EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='ivp_securityMaster_core_metadata' AND TABLE_SCHEMA='core')
drop table core.ivp_securityMaster_core_metadata;

go

create table core.ivp_securityMaster_core_metadata(
code bigint primary key identity,
attribute_name nvarchar(100) not null,
sectype_id bigint foreign key references core.ivp_securityMaster_core_sectype_id(code),
created_by nvarchar(50) not null,
created_on date,
is_active varchar(4)
);


go

--select * from core.ivp_securityMaster_core_metadata

IF EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='ivp_securityMaster_core_mastersecurity' AND TABLE_SCHEMA='core')
drop table core.ivp_securityMaster_core_mastersecurity;

go

create table core.ivp_securityMaster_core_mastersecurity(
code bigint primary key identity,
sectype_id bigint foreign key references core.ivp_securityMaster_core_sectype_id(code),
table_name nvarchar(100) not null unique
)

go

delete from core.ivp_securityMaster_core_securityidentifier

IF EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='ivp_securityMaster_core_securityidentifier' AND TABLE_SCHEMA='core')
drop table core.ivp_securityMaster_core_securityidentifier;

go
create table core.ivp_securityMaster_core_securityidentifier(
security_id bigint,
sectype int,
cusip nvarchar(100),
isin nvarchar(100),
sedol nvarchar(100),
bloomberg_ticker nvarchar(100),
bloomberg_unique_id varchar(max),
bloomberg_global_id varchar(max),
bloomberg_ticker_and_exchange varchar(max)
)

go

use MCA2015
select * from core.ivp_securityMaster_core_securityidentifier
delete from core.ivp_securityMaster_core_securityidentifier

select * from core.ivp_securityMaster_core_securityidentifier
insert into core.ivp_securityMaster_core_securityidentifier values
('security_id', 'cusip', 'isin', 'sedol', 'bloomberg_ticker', 'bloomberg_unique_id', 'bloomberg_global_id', 'bloomberg_ticker_and_exchange')

select * from core.ivp_securityMaster_core_securityidentifier

IF EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='ivp_securityMaster_core_referencedata' AND TABLE_SCHEMA='core')
drop table core.ivp_securityMaster_core_referencedata;

go
create table core.ivp_securityMaster_core_referencedata(
code bigint primary key,
sectype int,
issue_country nvarchar(100),
exchange nvarchar(100),
issuer nvarchar(100),
issue_currency nvarchar(100),
trading_currency nvarchar(100),
bloomberg_industry_sub_group nvarchar(100),
bloomberg_industry_group nvarchar(100),
bloomberg_industry_sector nvarchar(100),
country_of_incorporation nvarchar(100),
risk_currency nvarchar(100)
)

go


delete from core.ivp_securityMaster_core_referencedata

IF EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='ivp_securityMaster_securitysummary' AND TABLE_SCHEMA='eq')
drop table eq.ivp_securityMaster_securitysummary;

go

create table eq.ivp_securityMaster_securitysummary(
code bigint primary key identity,
security_name nvarchar(255) not null,
security_description nvarchar(255),
has_position varchar(4),
is_active varchar(4),
round_lot_size varchar(max),
bloomberg_unique_name nvarchar(255) unique,
)

go



IF EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='ivp_securityMaster_securitydetails' AND TABLE_SCHEMA='eq')
drop table eq.ivp_securityMaster_securitydetails;

go

create table eq.ivp_securityMaster_securitydetails(
code bigint primary key identity foreign key references eq.ivp_securityMaster_securitysummary(code),
is_adr varchar(max),
adr_underlying_ticker nvarchar(100),
adr_underlying_currency nvarchar(100),
shares_per_adr nvarchar(100),
ipo_date varchar(max),
price_currency nvarchar(100),
settle_days bigint,
shares_outstanding nvarchar(100),
voting_rights_per_share nvarchar(100),
form_pf_asset_class nvarchar(100),
form_pf_country nvarchar(100),
form_pf_credit_rating nvarchar(100),
form_pf_currency nvarchar(100),
form_pf_instrument nvarchar(100),
form_pf_liquid_profile nvarchar(100),
form_pf_maturity nvarchar(100),
form_pf_naics_code nvarchar(100),
form_pf_region nvarchar(100),
form_pf_sector nvarchar(100),
form_pf_sub_asset_class nvarchar(100)
)

go

IF EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='ivp_securityMaster_risk' AND TABLE_SCHEMA='eq')
drop table eq.ivp_securityMaster_risk;

go

create table eq.ivp_securityMaster_risk(
code bigint primary key identity foreign key references eq.ivp_securityMaster_securitysummary(code),
twenty_day_average_volume nvarchar(100),
beta nvarchar(100),
short_interest nvarchar(100),
ytd_return nvarchar(100),
ninty_day_price_volatility nvarchar(100),
)

go

IF EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='ivp_securityMaster_pricingdetails' AND TABLE_SCHEMA='eq')
drop table eq.ivp_securityMaster_pricingdetails;

go

create table eq.ivp_securityMaster_pricingdetails(
code bigint primary key identity,
open_price varchar(max),
close_price varchar(max),
volume bigint,
last_price varchar(max),
ask_price varchar(max),
bid_price varchar(max),
pe_ratio float
)

go

IF EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='ivp_securityMaster_dividendhistory' AND TABLE_SCHEMA='eq')
drop table eq.ivp_securityMaster_dividendhistory;

go

create table eq.ivp_securityMaster_dividendhistory(
code bigint primary key identity,
declared_date date,
ex_date date,
record_date date,
pay_date date,
amount varchar(max),
frequency nvarchar(100),
dividend_type nvarchar(100)
)
go
select * from eq.ivp_securityMaster_dividendhistory


use MCA2015
/***************Corporate Bond**********************/

go

IF EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='ivp_securityMaster_securitysummary' AND TABLE_SCHEMA='cb')
drop table cb.ivp_securityMaster_securitysummary;

go

create table cb.ivp_securityMaster_securitysummary(
code bigint primary key identity(100000,1),
security_description nvarchar(100),
security_name nvarchar(100),
asset_type nvarchar(100),
investment_type nvarchar(100),
trading_factor nvarchar(100),
pricing_factor nvarchar(100),
--created_by nvarchar(50) not null,
--created_on varchar(max),
--last_modified_by nvarchar(50),
--last_modified_on varchar(max),
is_active varchar(4)
)

go

IF EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='ivp_securityMaster_securitydetails' AND TABLE_SCHEMA='cb')
drop table cb.ivp_securityMaster_securitydetails;

go

create table cb.ivp_securityMaster_securitydetails(
code bigint primary key identity,
fk_security_id bigint foreign key references  cb.ivp_securityMaster_securitysummary(security_id),
first_coupondate varchar(max),
coupon_cap nvarchar(100),
coupon_floor nvarchar(100),
coupon_frequency nvarchar(100),
coupon_rate nvarchar(100),
coupon_type nvarchar(100),
float_spread nvarchar(100),
is_callable varchar(4),
is_fix_to_float varchar(4),
is_putable varchar(4),
issuedate varchar(max),
last_resetdate varchar(max),
maturitydate varchar(max),
maximum_call_notice_days bigint,
maximum_put_notice_days bigint,
penultimate_coupondate varchar(max),
reset_frequency nvarchar(100),
has_position varchar(4),
form_pf_asset_class nvarchar(100),
form_pf_country nvarchar(100),
form_pf_credit_rating nvarchar(100),
form_pf_currency nvarchar(100),
form_pf_instrument nvarchar(100),
form_pf_liquidity_profile nvarchar(100),
form_pf_maturity nvarchar(100),
form_pf_naics_code nvarchar(100),
form_pf_region nvarchar(100),
form_pf_sector nvarchar(100),
form_pf_sub_asset_class nvarchar(100)
)

go

IF EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='ivp_securityMaster_risk' AND TABLE_SCHEMA='cb')
drop table cb.ivp_securityMaster_risk;

go

create table cb.ivp_securityMaster_risk(
code bigint primary key identity,
fk_security_id bigint foreign key references  cb.ivp_securityMaster_securitysummary(security_id),
firstcouponcode nvarchar(100),
duration nvarchar(100),
volatility_thirtyD nvarchar(100),
volatility_nintyD nvarchar(100),
convexity nvarchar(100),
average_volume_thirtyD nvarchar(100)
)

go

IF EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='ivp_securityMaster_putschedule' AND TABLE_SCHEMA='cb')
drop table cb.ivp_securityMaster_putschedule;

go

create table cb.ivp_securityMaster_putschedule(
code bigint primary key identity,
fk_security_id bigint foreign key references  cb.ivp_securityMaster_securitysummary(security_id),
putdate varchar(max),
put_price varchar(max),
)

go

IF EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='ivp_securityMaster_pricingandanalytics' AND TABLE_SCHEMA='cb')
drop table cb.ivp_securityMaster_pricingandanalytics;

go

create table cb.ivp_securityMaster_pricingandanalytics(
code bigint primary key identity,
fk_security_id bigint foreign key references  cb.ivp_securityMaster_securitysummary(security_id),
ask_price varchar(max),
high_price varchar(max),
low_price varchar(max),
open_price varchar(max),
volume bigint,
bid_price varchar(max),
last_price varchar(max)
)

go

IF EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='ivp_securityMaster_callschedule' AND TABLE_SCHEMA='cb')
drop table cb.ivp_securityMaster_pricingandanalytics;

go

create table cb.ivp_securityMaster_callschedule(
code bigint primary key identity,
fk_security_id bigint foreign key references  cb.ivp_securityMaster_securitysummary(security_id),
calldate varchar(max),
call_price varchar(max),
)

go

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[eq].[sp_ivp_securityMaster_iud_security]') AND type in (N'P', N'PC'))
DROP PROCEDURE eq.sp_ivp_securityMaster_iud_security

GO

use mca2015


go
create table core.ivp_securitymaster_attributeFieldMapper(
code bigint primary key identity,
attribute_name_in_db varchar(max) not null,
attribute_name_in_file varchar(max) not null,
sectype_id bigint foreign key references core.ivp_secm_core_sectype_id(code),
containing_table varchar(max) not null,
created_by nvarchar(50) not null,
created_on date,
is_active varchar(4)
);

go

delete from core.ivp_securitymaster_attributeFieldMapping
select * from core.ivp_securitymaster_attributeFieldMapping
insert into core.ivp_securitymaster_attributeFieldMapping values
('security_name', 'Security Name', 1, 'core.ivp_securitymaster_securitysummary', 'Ashish', '06.02.2015', 'true'),
('security_description', 'Security Description', 1, 'core.ivp_securitymaster_securitysummary', 'Ashish', '06.02.2015', 'true'),
('has_position', 'Has Position', 1, 'core.ivp_securitymaster_securitysummary', 'Ashish', '06.02.2015', 'true'),
('is_active', 'Is Active Security', 1, 'core.ivp_securitymaster_securitysummary', 'Ashish', '06.02.2015', 'true'),
('round_lot_size', 'Round Lot Size', 1, 'core.ivp_securitymaster_securitysummary', 'Ashish', '06.02.2015', 'true'),
('bloomberg_unique_name', 'BBG Unique Name', 1, 'core.ivp_securitymaster_securitysummary', 'Ashish', '06.02.2015', 'true'),
('cusip', 'CUSIP', 1, 'core.ivp_securitymaster_securityidentifier', 'Ashish', '06.02.2015', 'true'),
('isin', 'isin', 1, 'core.ivp_securitymaster_attributeFieldMapping', 'Ashish', '06.02.2015', 'true'),
('security_description', 'Security Description', 1, 'core.ivp_securitymaster_attributeFieldMapping', 'Ashish', '06.02.2015', 'true'),
('security_description', 'Security Description', 1, 'core.ivp_securitymaster_attributeFieldMapping', 'Ashish', '06.02.2015', 'true'),
('security_description', 'Security Description', 1, 'core.ivp_securitymaster_attributeFieldMapping', 'Ashish', '06.02.2015', 'true'),
('security_description', 'Security Description', 1, 'core.ivp_securitymaster_attributeFieldMapping', 'Ashish', '06.02.2015', 'true'),
('security_description', 'Security Description', 1, 'core.ivp_securitymaster_attributeFieldMapping', 'Ashish', '06.02.2015', 'true'),
('security_description', 'Security Description', 1, 'core.ivp_securitymaster_attributeFieldMapping', 'Ashish', '06.02.2015', 'true'),
('security_description', 'Security Description', 1, 'core.ivp_securitymaster_attributeFieldMapping', 'Ashish', '06.02.2015', 'true')



