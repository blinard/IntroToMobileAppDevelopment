package com.example.introtomobileappdevelopment;

import android.app.AlertDialog;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import retrofit.RestAdapter;
import rx.Observable;
import rx.Observer;
import rx.Subscription;
import rx.android.schedulers.AndroidSchedulers;
import rx.android.subscriptions.AndroidSubscriptions;


public class MainActivity extends ActionBarActivity {

    private Button btnGetANumber;
    private TextView lblNumber;
    private IRandomNumberGenerator _randomNumberGenerator;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        btnGetANumber = (Button)findViewById(R.id.btnGetANumber);
        lblNumber = (TextView)findViewById(R.id.lblNumber);
        RestAdapter restAdapter = new RestAdapter.Builder()
                .setEndpoint("http://introtomobileappdevelopment.azurewebsites.net/api")
                .build();
        _randomNumberGenerator = restAdapter.create(IRandomNumberGenerator.class);

        btnGetANumber.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Observable<Integer> observableNumber = _randomNumberGenerator.GetRandomNumber().observeOn(AndroidSchedulers.mainThread());
                observableNumber.subscribe(new Observer<Integer>() {
                    @Override
                    public void onCompleted() {
                    }

                    @Override
                    public void onError(Throwable e) {
                        AlertDialog.Builder alertBuilder = new AlertDialog.Builder(MainActivity.this);
                        alertBuilder.setMessage("Oops, an error occurred: " + e.getMessage());
                        alertBuilder.setTitle("Error");
                        alertBuilder.create().show();
                    }

                    @Override
                    public void onNext(Integer integer) {
                        lblNumber.setText("Your number is:\n" + integer.toString());
                    }
                });
            }
        });
    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
}
