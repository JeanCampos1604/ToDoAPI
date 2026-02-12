/* ---------------------------------------------------------------------- */
/* Script generated with: DeZign for Databases V8.1.2                     */
/* Target DBMS:           Oracle 10g                                      */
/* Project file:          Modelo.dez                                      */
/* Project name:                                                          */
/* Author:                                                                */
/* Script type:           Database creation script                        */
/* Created on:            2026-02-12 11:29                                */
/* ---------------------------------------------------------------------- */


/* ---------------------------------------------------------------------- */
/* Add tables                                                             */
/* ---------------------------------------------------------------------- */

/* ---------------------------------------------------------------------- */
/* Add table "NOTES"                                                      */
/* ---------------------------------------------------------------------- */

CREATE TABLE NOTES (
    ID VARCHAR2(36) CONSTRAINT NN_NOTES_ID NOT NULL,
    TITLE VARCHAR2(200),
    DESCRIPTION CLOB,
    PRIORITY VARCHAR2(50),
    CATEGORY VARCHAR2(100),
    ISCOMPLETED NUMBER(1) DEFAULT 0 CONSTRAINT NN_NOTES_ISCOMPLETED NOT NULL,
    CREATEDAT DATE,
    UPDATEDAT DATE,
    CONSTRAINT PK_NOTES PRIMARY KEY (ID)
);
