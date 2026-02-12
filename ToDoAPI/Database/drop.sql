/* ---------------------------------------------------------------------- */
/* Script generated with: DeZign for Databases V8.1.2                     */
/* Target DBMS:           Oracle 10g                                      */
/* Project file:          Modelo.dez                                      */
/* Project name:                                                          */
/* Author:                                                                */
/* Script type:           Database drop script                            */
/* Created on:            2026-02-12 11:29                                */
/* ---------------------------------------------------------------------- */


/* ---------------------------------------------------------------------- */
/* Drop table "NOTES"                                                     */
/* ---------------------------------------------------------------------- */

/* Drop constraints */

ALTER TABLE NOTES DROP CONSTRAINT NN_NOTES_ID;

ALTER TABLE NOTES DROP CONSTRAINT NN_NOTES_ISCOMPLETED;

ALTER TABLE NOTES DROP CONSTRAINT PK_NOTES;

DROP TABLE NOTES;
