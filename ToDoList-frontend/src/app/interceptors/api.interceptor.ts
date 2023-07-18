import { Injectable } from "@angular/core";
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest } from "@angular/common/http";
import { Observable, finalize } from "rxjs";
import { LoaderService } from "../services/loader-service";
import { ToastrService } from "ngx-toastr";

@Injectable({ providedIn: "root" })
export class ApiInterceptor implements HttpInterceptor {
  constructor(
    private loaderService: LoaderService,
    private toastr: ToastrService
    ) {}

  private totalRequests = 0;

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    this.totalRequests++;
    this.loaderService.setLoading(true);
    const apiReq = req.clone({ url: `https://localhost:7247/api/${req.url}` });
    return next.handle(apiReq).pipe(
      finalize(() => {
        this.totalRequests--;
        if (this.totalRequests === 0) {
          this.loaderService.setLoading(false);
        }
      })
    );
  }
}
