using System;

namespace RatingAdjustment.Services
{
    /** Service calculating a star rating accounting for the number of reviews
     * 
     */
    public class RatingAdjustmentService
    {
        const double MAX_STARS = 5.0;  // Likert scale
        const double Z = 1.96; // 95% confidence interval

        double _q;
        double _percent_positive;

        /** Percentage of positive reviews
         * 
         * In this case, that means X of 5 ==> percent positive
         * 
         * Returns: [0, 1]
         */
        void SetPercentPositive(double stars)
        {
            // TODO: Implement this!
            _percent_positive = (stars * 20) / 100;



        }

        /**
         * Calculate "Q" given the formula in the problem statement
         */
        void SetQ(double number_of_ratings)
        {
            // TODO: Implement this!
            double num = number_of_ratings;
            double percentage = _percent_positive;
            _q = Z * Math.Sqrt(((percentage * (1 - percentage)) + ((Z * Z) / (4 * num))) / num);



        }

        /** Adjusted lower bound
         * 
         * Lower bound of the confidence interval around the star rating.
         * 
         * Returns: a double, up to 5
         */
        public double Adjust(double stars, double number_of_ratings)
        {
            // TODO: Implement this!
            SetPercentPositive(stars);
            SetQ(number_of_ratings);
            double number = number_of_ratings;
            double percentage = _percent_positive;
            double IB = ((percentage + ((Z * Z) / (2 * number)) - _q) / (1 + ((Z * Z) / number))) * MAX_STARS;
            if (IB <= MAX_STARS)
            {
                return IB;
            }
            else
            {
                return stars;
            }

        }
    }
}
