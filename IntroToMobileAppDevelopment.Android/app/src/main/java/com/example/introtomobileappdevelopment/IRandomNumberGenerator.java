package com.example.introtomobileappdevelopment;

import retrofit.http.GET;
import rx.Observable;

/**
 * Created by bradlinard on 2/8/15.
 */
public interface IRandomNumberGenerator {

    @GET("/RandomNumber")
    Observable<Integer> GetRandomNumber();
}
