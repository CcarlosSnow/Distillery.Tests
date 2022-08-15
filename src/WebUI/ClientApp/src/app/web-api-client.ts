//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.16.0.0 (NJsonSchema v10.7.1.0 (Newtonsoft.Json v13.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

/* tslint:disable */
/* eslint-disable */
// ReSharper disable InconsistentNaming

import { mergeMap as _observableMergeMap, catchError as _observableCatch } from 'rxjs/operators';
import { Observable, throwError as _observableThrow, of as _observableOf } from 'rxjs';
import { Injectable, Inject, Optional, InjectionToken } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse, HttpResponseBase } from '@angular/common/http';

export const API_BASE_URL = new InjectionToken<string>('API_BASE_URL');

export interface ICreditCardClient {
    create(command: CreateCreditCardCommand): Observable<number>;
    consumes(id: number, command: CreateCardBalanceCommand): Observable<number>;
    get(id: number): Observable<GetCreditCardByIdDto>;
}

@Injectable({
    providedIn: 'root'
})
export class CreditCardClient implements ICreditCardClient {
    private http: HttpClient;
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
        this.http = http;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    }

    create(command: CreateCreditCardCommand): Observable<number> {
        let url_ = this.baseUrl + "/api/CreditCard";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(command);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json",
                "Accept": "application/json"
            })
        };

        return this.http.request("post", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processCreate(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processCreate(response_ as any);
                } catch (e) {
                    return _observableThrow(e) as any as Observable<number>;
                }
            } else
                return _observableThrow(response_) as any as Observable<number>;
        }));
    }

    protected processCreate(response: HttpResponseBase): Observable<number> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (response as any).error instanceof Blob ? (response as any).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                result200 = resultData200 !== undefined ? resultData200 : <any>null;
    
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf(null as any);
    }

    consumes(id: number, command: CreateCardBalanceCommand): Observable<number> {
        let url_ = this.baseUrl + "/api/CreditCard/{Id}/pay";
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace("{Id}", encodeURIComponent("" + id));
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(command);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json",
                "Accept": "application/json"
            })
        };

        return this.http.request("post", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processConsumes(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processConsumes(response_ as any);
                } catch (e) {
                    return _observableThrow(e) as any as Observable<number>;
                }
            } else
                return _observableThrow(response_) as any as Observable<number>;
        }));
    }

    protected processConsumes(response: HttpResponseBase): Observable<number> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (response as any).error instanceof Blob ? (response as any).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                result200 = resultData200 !== undefined ? resultData200 : <any>null;
    
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf(null as any);
    }

    get(id: number): Observable<GetCreditCardByIdDto> {
        let url_ = this.baseUrl + "/api/CreditCard/{Id}";
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace("{Id}", encodeURIComponent("" + id));
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "application/json"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGet(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGet(response_ as any);
                } catch (e) {
                    return _observableThrow(e) as any as Observable<GetCreditCardByIdDto>;
                }
            } else
                return _observableThrow(response_) as any as Observable<GetCreditCardByIdDto>;
        }));
    }

    protected processGet(response: HttpResponseBase): Observable<GetCreditCardByIdDto> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (response as any).error instanceof Blob ? (response as any).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = GetCreditCardByIdDto.fromJS(resultData200);
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf(null as any);
    }
}

export class CreateCreditCardCommand implements ICreateCreditCardCommand {
    cardNumber?: string;
    totalCredit?: number;
    cardOwner?: string;

    constructor(data?: ICreateCreditCardCommand) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.cardNumber = _data["cardNumber"];
            this.totalCredit = _data["totalCredit"];
            this.cardOwner = _data["cardOwner"];
        }
    }

    static fromJS(data: any): CreateCreditCardCommand {
        data = typeof data === 'object' ? data : {};
        let result = new CreateCreditCardCommand();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["cardNumber"] = this.cardNumber;
        data["totalCredit"] = this.totalCredit;
        data["cardOwner"] = this.cardOwner;
        return data;
    }
}

export interface ICreateCreditCardCommand {
    cardNumber?: string;
    totalCredit?: number;
    cardOwner?: string;
}

export class CreateCardBalanceCommand implements ICreateCardBalanceCommand {
    movementDate?: Date;
    amout?: number;
    creditCardId?: number;

    constructor(data?: ICreateCardBalanceCommand) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.movementDate = _data["movementDate"] ? new Date(_data["movementDate"].toString()) : <any>undefined;
            this.amout = _data["amout"];
            this.creditCardId = _data["creditCardId"];
        }
    }

    static fromJS(data: any): CreateCardBalanceCommand {
        data = typeof data === 'object' ? data : {};
        let result = new CreateCardBalanceCommand();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["movementDate"] = this.movementDate ? this.movementDate.toISOString() : <any>undefined;
        data["amout"] = this.amout;
        data["creditCardId"] = this.creditCardId;
        return data;
    }
}

export interface ICreateCardBalanceCommand {
    movementDate?: Date;
    amout?: number;
    creditCardId?: number;
}

export class GetCreditCardByIdDto implements IGetCreditCardByIdDto {
    summary?: CreditCardSummary;
    balances?: CreditCardBalance[];

    constructor(data?: IGetCreditCardByIdDto) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.summary = _data["summary"] ? CreditCardSummary.fromJS(_data["summary"]) : <any>undefined;
            if (Array.isArray(_data["balances"])) {
                this.balances = [] as any;
                for (let item of _data["balances"])
                    this.balances!.push(CreditCardBalance.fromJS(item));
            }
        }
    }

    static fromJS(data: any): GetCreditCardByIdDto {
        data = typeof data === 'object' ? data : {};
        let result = new GetCreditCardByIdDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["summary"] = this.summary ? this.summary.toJSON() : <any>undefined;
        if (Array.isArray(this.balances)) {
            data["balances"] = [];
            for (let item of this.balances)
                data["balances"].push(item.toJSON());
        }
        return data;
    }
}

export interface IGetCreditCardByIdDto {
    summary?: CreditCardSummary;
    balances?: CreditCardBalance[];
}

export class CreditCardSummary implements ICreditCardSummary {
    id?: number;
    cardNumber?: string;
    totalCredit?: number;
    currentCredit?: number;
    cardOwner?: string;

    constructor(data?: ICreditCardSummary) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.id = _data["id"];
            this.cardNumber = _data["cardNumber"];
            this.totalCredit = _data["totalCredit"];
            this.currentCredit = _data["currentCredit"];
            this.cardOwner = _data["cardOwner"];
        }
    }

    static fromJS(data: any): CreditCardSummary {
        data = typeof data === 'object' ? data : {};
        let result = new CreditCardSummary();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        data["cardNumber"] = this.cardNumber;
        data["totalCredit"] = this.totalCredit;
        data["currentCredit"] = this.currentCredit;
        data["cardOwner"] = this.cardOwner;
        return data;
    }
}

export interface ICreditCardSummary {
    id?: number;
    cardNumber?: string;
    totalCredit?: number;
    currentCredit?: number;
    cardOwner?: string;
}

export class CreditCardBalance implements ICreditCardBalance {
    movementDate?: Date;
    amout?: number;
    fee?: number;
    feeAmount?: number;
    paymentAmount?: number;

    constructor(data?: ICreditCardBalance) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.movementDate = _data["movementDate"] ? new Date(_data["movementDate"].toString()) : <any>undefined;
            this.amout = _data["amout"];
            this.fee = _data["fee"];
            this.feeAmount = _data["feeAmount"];
            this.paymentAmount = _data["paymentAmount"];
        }
    }

    static fromJS(data: any): CreditCardBalance {
        data = typeof data === 'object' ? data : {};
        let result = new CreditCardBalance();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["movementDate"] = this.movementDate ? this.movementDate.toISOString() : <any>undefined;
        data["amout"] = this.amout;
        data["fee"] = this.fee;
        data["feeAmount"] = this.feeAmount;
        data["paymentAmount"] = this.paymentAmount;
        return data;
    }
}

export interface ICreditCardBalance {
    movementDate?: Date;
    amout?: number;
    fee?: number;
    feeAmount?: number;
    paymentAmount?: number;
}

export class SwaggerException extends Error {
    override message: string;
    status: number;
    response: string;
    headers: { [key: string]: any; };
    result: any;

    constructor(message: string, status: number, response: string, headers: { [key: string]: any; }, result: any) {
        super();

        this.message = message;
        this.status = status;
        this.response = response;
        this.headers = headers;
        this.result = result;
    }

    protected isSwaggerException = true;

    static isSwaggerException(obj: any): obj is SwaggerException {
        return obj.isSwaggerException === true;
    }
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): Observable<any> {
    if (result !== null && result !== undefined)
        return _observableThrow(result);
    else
        return _observableThrow(new SwaggerException(message, status, response, headers, null));
}

function blobToText(blob: any): Observable<string> {
    return new Observable<string>((observer: any) => {
        if (!blob) {
            observer.next("");
            observer.complete();
        } else {
            let reader = new FileReader();
            reader.onload = event => {
                observer.next((event.target as any).result);
                observer.complete();
            };
            reader.readAsText(blob);
        }
    });
}