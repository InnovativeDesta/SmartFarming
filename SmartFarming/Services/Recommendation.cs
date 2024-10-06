using System;

namespace SmartFarming.Services
{
    public class Recommendation
    {
        private Random _random = new Random();

        public (double soilMoisture, bool floodRisk, bool droughtRisk, string message) SimulateAndGenerateRecommendation(string vegetationType)
        {
            // Simulate random values
            double soilMoisture = _random.NextDouble();  // Generates a random number between 0.0 and 1.0
            bool floodRisk = _random.Next(0, 2) == 1;  // Generates either true or false
            bool droughtRisk = _random.Next(0, 2) == 1;  // Generates either true or false

            // Generate a recommendation based on simulated values
            string recommendation = GenerateRecommendation(vegetationType, soilMoisture, floodRisk, droughtRisk);

            return (soilMoisture, floodRisk, droughtRisk, recommendation);
        }


        public string GenerateRecommendation(string vegetationType, double soilMoisture, bool floodRisk, bool droughtRisk)
        {
            // Base recommendation message
            string recommendation = $"For {vegetationType}: \n";

            // Different crops have different soil moisture needs, flood and drought tolerances
            return vegetationType.ToLower() switch
            {
                "tomato" => GenerateTomatoRecommendations(soilMoisture, floodRisk, droughtRisk),
                "lettuce" => GenerateLettuceRecommendations(soilMoisture, floodRisk, droughtRisk),
                "corn" => GenerateCornRecommendations(soilMoisture, floodRisk, droughtRisk),
                "rice" => GenerateRiceRecommendation(soilMoisture, floodRisk, droughtRisk),
                "wheat" => GenerateWheatRecommendation(soilMoisture, floodRisk, droughtRisk),
                "apple" => GenerateAppleRecommendation(soilMoisture, floodRisk, droughtRisk),
                _ => "No recommendations available for the selected vegetation type."
            };
        }

        private string GenerateTomatoRecommendations(double soilMoisture, bool floodRisk, bool droughtRisk)
        {
            string recommendation = "";

            if (soilMoisture < 0.3)
            {
                recommendation += "Tomatoes require more water. Soil moisture is too low, consider irrigating immediately.\n";
            }
            else if (soilMoisture > 0.8)
            {
                recommendation += "Soil moisture is too high for tomatoes. Ensure proper drainage to avoid root rot.\n";
            }
            else
            {
                recommendation += "Soil moisture is within optimal range for tomatoes.\n";
            }

            if (floodRisk)
            {
                recommendation += "Flood risk detected. Tomatoes are vulnerable to waterlogging. Protect them with raised beds or drainage systems.\n";
            }

            if (droughtRisk)
            {
                recommendation += "Drought risk detected. Tomatoes are moderately drought-tolerant but still require consistent watering.\n";
            }

            return recommendation;
        }

        private string GenerateLettuceRecommendations(double soilMoisture, bool floodRisk, bool droughtRisk)
        {
            string recommendation = "";

            if (soilMoisture < 0.4)
            {
                recommendation += "Lettuce needs a lot of water. Soil moisture is too low. Irrigate regularly.\n";
            }
            else if (soilMoisture > 0.9)
            {
                recommendation += "Lettuce does not tolerate overwatering. Ensure the soil is well-drained.\n";
            }
            else
            {
                recommendation += "Soil moisture is optimal for lettuce.\n";
            }

            if (floodRisk)
            {
                recommendation += "Flood risk detected. Lettuce is highly susceptible to waterlogging. Ensure proper drainage to prevent crop loss.\n";
            }

            if (droughtRisk)
            {
                recommendation += "Drought risk detected. Lettuce is not drought-tolerant and requires frequent watering.\n";
            }

            return recommendation;
        }

        private string GenerateCornRecommendations(double soilMoisture, bool floodRisk, bool droughtRisk)
        {
            string recommendation = "";

            if (soilMoisture < 0.2)
            {
                recommendation += "Corn requires deep watering. Soil moisture is critically low. Irrigate immediately.\n";
            }
            else if (soilMoisture > 0.7)
            {
                recommendation += "Corn tolerates higher moisture levels, but avoid waterlogging.\n";
            }
            else
            {
                recommendation += "Soil moisture is optimal for corn.\n";
            }

            if (floodRisk)
            {
                recommendation += "Flood risk detected. Corn can survive some waterlogging but ensure good drainage for optimal growth.\n";
            }

            if (droughtRisk)
            {
                recommendation += "Drought risk detected. Corn is highly susceptible to drought during pollination. Ensure consistent irrigation.\n";
            }

            return recommendation;
        }
        private string GenerateRiceRecommendation(double soilMoisture, bool isDrought, bool isFlood)
        {
            if (isFlood)
                return "Rice is sensitive to flooding. Ensure proper drainage to avoid crop loss.";
            else if (isDrought)
                return "Consider irrigating your rice fields if soil moisture falls below 30%.";
            else if (soilMoisture < 30)
                return "Soil moisture is low. Irrigation is recommended.";
            else
                return "Conditions are optimal for rice cultivation.";
        }

        private string GenerateWheatRecommendation(double soilMoisture, bool isDrought, bool isFlood)
        {
            if (isFlood)
                return "Flood conditions can harm wheat crops. Ensure good drainage.";
            else if (isDrought)
                return "Wheat requires consistent moisture. Irrigate if moisture drops below 40%.";
            else if (soilMoisture < 40)
                return "Soil moisture is low. Consider irrigating your wheat fields.";
            else
                return "Conditions are favorable for wheat growth.";
        }

        private string GenerateAppleRecommendation(double soilMoisture, bool isDrought, bool isFlood)
        {
            if (isFlood)
                return "Flooding can damage apple roots. Ensure proper drainage.";
            else if (isDrought)
                return "Drought stress can affect apple yield. Water your apple trees if soil moisture drops below 30%.";
            else if (soilMoisture < 30)
                return "Low soil moisture detected. Irrigation is recommended for healthy apple trees.";
            else
                return "Conditions are suitable for apple growth.";
        }
    }
}
