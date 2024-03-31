filename = 'firedata.xlsx';

data = xlsread(filename);

x = data(:, 1);
y = data(:, 2);


plot(x, y, '-');
xlabel('Time (sec)');
ylabel("Eye Level Temperature (Degrees Farenheit)");
title("Living Room");
grid on;

%find the local maxima
[maxima_values, maxima_indices] = findpeaks(y);

%plot the data with local maxima
plot(x, y);
hold on;
plot(x(maxima_indices), maxima_values, 'r*', 'MarkerSize', 10);
hold off;

xlabel('Time (sec)');
ylabel("Eye Level Temperature (Degrees Fahrenheit)");
title("Living Room");
grid on;
legend('Data', 'Local Maxima');


%for interval peaks
%define interval of y
y_interval_min = 620; % Example lower bound
y_interval_max = 650; % Example upper bound

%find local maxima within specified interval
[maxima_values, maxima_indices] = findpeaks(y);
maxima_within_interval = maxima_values(y(maxima_indices) >= y_interval_min & y(maxima_indices) <= y_interval_max);

%find indices of local maxima within specified interval
maxima_indices_within_interval = maxima_indices(y(maxima_indices) >= y_interval_min & y(maxima_indices) <= y_interval_max);

%plot data with local maxima within interval
plot(x, y);
hold on;
plot(x(maxima_indices_within_interval), maxima_within_interval, 'r*', 'MarkerSize', 10);
hold off;

xlabel('Time (sec)');
ylabel("Eye Level Temperature (Degrees Fahrenheit)");
title("Living Room");
grid on;
legend('Data', 'Local Maxima within Interval');