import { Injectable } from "@angular/core"


export namespace ConstansUrlService{

    
    export const createStudents = "/Student/PostStudent"
    export const getStudents = "/Student/GetStudents"
    export const updateStudent = "/Student"
    export const deleteStudent = "/Student"

    // books
    export const getBooksById = "/Book/getBooksById?id="
    export const getbooks = "/Book/getbooks"
    export const PostBooks = "/Book/PostBooks"



    // studentbooks
    export const getByStuId = "/StudentBooks/getByStuId?sId="
    export const StudentBooksAdd = "/StudentBooks/StudentBooksAdd"
    
    // student Payments
    export const GetStuPaymentbyid = "/StudentPayments/GetStuPayment?id="
    export const PostStuPayment = "/StudentPayments/PostStuPayment"

}