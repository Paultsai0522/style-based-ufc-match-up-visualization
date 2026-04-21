import { fightsDataPath } from "./config.js";   

let currentBrush1Fighters = [];
let currentBrush2Fighters = [];
let currentColorScheme = "default";

const rdBuColorScale = d3.scaleSequential(d3.interpolateRdBu).domain([1, -1]);
const ylGnColorScale = d3.scaleSequential(d3.interpolateYlGn).domain([-1, 1]);

function createColorLegend(svg, colorScale, width, height) {
    const legendHeight = 200;
    const legendWidth = 20;
    const legendMargin = { top: 10, right: 20, bottom: 10, left: 10 };

    // Unique identifier for the gradient (to avoid conflicts in the SVG)
    const gradientId = `gradient-${Math.random().toString(36).substr(2, 9)}`;

    // Create a group for the legend
    const legend = svg.append("g")
        .attr("transform", `translate(${width - legendMargin.right - legendWidth}, ${height / 2 - legendHeight / 2})`);

    // Create a linear gradient
    const linearGradient = svg.append("defs").append("linearGradient")
        .attr("id", gradientId)
        .attr("x1", "0%")
        .attr("x2", "0%")
        .attr("y1", "100%")
        .attr("y2", "0%");

    // Define the gradient stops
    const numStops = 10;
    d3.range(numStops).forEach(i => {
        linearGradient.append("stop")
            .attr("offset", `${i / (numStops - 1) * 100}%`)
            .attr("stop-color", colorScale(i / (numStops - 1) * 2 - 1));
    });

    // Append the rectangle for the legend
    legend.append("rect")
        .attr("width", legendWidth)
        .attr("height", legendHeight)
        .style("fill", `url(#${gradientId})`);
    
    // Append legend scale
    const legendScale = d3.scaleLinear()
        .range([legendHeight, 0])
        .domain(colorScale.domain());

    const legendAxis = d3.axisRight(legendScale)
        .tickSize(0)
        .ticks(5);

    legend.append("g")
        .attr("transform", `translate(${legendWidth}, 0)`)
        .attr("color", "white")
        .call(legendAxis)
        .call(g => g.select(".domain").remove());
}

async function drawPyramidChart(dataPath, brush1Fighters, brush2Fighters, useFilteredData, colorScheme) {
    // Clear existing content
    const svgContainer = d3.select("#pyramidChart");
    let dataToUse;

    svgContainer.selectAll("*").remove();
        
    currentBrush1Fighters = brush1Fighters;
    currentBrush2Fighters = brush2Fighters;

    if (useFilteredData) {
        // Fetch filtered data based on brushed fighters
        const response = await fetch(`${dataPath}/brush`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                Brush1_fighters: brush1Fighters,
                Brush2_fighters: brush2Fighters
             })
            }
        );
        dataToUse = await response.json();
        console.log("Filtered data fetched:", dataToUse);
    } else {
        // Use all fights
        const response = await fetch(dataPath);
        dataToUse = await response.json();
    }

    // Filter fightData based on brushed fighters and fights that already happened

    // Process data for correlation calculation
    const metrics = [
        'avg_KD', 'avg_REV', 'avg_SIG_STR_att', 
        'avg_SIG_STR_landed', 'avg_TOTAL_STR_att', 'avg_TOTAL_STR_landed', 
        'avg_TD_att', 'avg_TD_landed', 'avg_HEAD_att', 'avg_HEAD_landed', 
        'avg_BODY_att', 'avg_BODY_landed', 'avg_LEG_att', 'avg_LEG_landed', 
        'avg_DISTANCE_att', 'avg_DISTANCE_landed', 'avg_CLINCH_att', 'avg_CLINCH_landed', 
        'avg_GROUND_att', 'avg_GROUND_landed'
    ];

    // Convert to numeric and handle non-numeric values
    dataToUse.forEach(fight => {
        metrics.forEach(metric => {
            fight[metric] = isNaN(parseFloat(fight[metric])) ? 0 : parseFloat(fight[metric]);
        });

        // Determine wins for brush groups
        fight.brush1Win = brush1Fighters.includes(fight.Winner) ? 1 : 0;
        fight.brush2Win = brush2Fighters.includes(fight.Winner) ? 1 : 0;
    });

    const averages = calculateAverages(dataToUse, metrics, brush1Fighters, brush2Fighters);

    // Calculate correlations for brushed fighters
    const correlationsBrush1 = calculateCorrelations(dataToUse, metrics, brush1Fighters);
    const correlationsBrush2 = calculateCorrelations(dataToUse, metrics, brush2Fighters);

    // Combine correlations
    let combinedCorrelations = combineCorrelations(correlationsBrush1, correlationsBrush2);

    console.log(combinedCorrelations);

    // Define color scales based on the color scheme
    let colorScaleBrush1, colorScaleBrush2;

    if (colorScheme === 'rdBu') {
        colorScaleBrush1 = d => colorScaleR(combinedCorrelations.find(c => c.metric === d.metric).brush1Correlation);
        colorScaleBrush2 = d => colorScaleB(combinedCorrelations.find(c => c.metric === d.metric).brush2Correlation);
    } else if (colorScheme === 'ylGn') {
        colorScaleBrush1 = colorScaleBrush2 = d => colorScaleG(combinedCorrelations.find(c => c.metric === d.metric).brush1Correlation);
    } else { // Default R&B
        colorScaleBrush1 = () => "#ef8a62";
        colorScaleBrush2 = () => "#67a9cf";
    }

    // Visualization setup
    const margin = { top: 20, right: 30, bottom: 120, left: 120 },
            width = 720 - margin.left - margin.right,
            height = 720 - margin.top - margin.bottom;

    // Create SVG
    const svg = svgContainer.append("svg")
        .attr("width", width + margin.left + margin.right)
        .attr("height", height + margin.top + margin.bottom)
        .append("g")
        .attr("transform", `translate(${margin.left},${margin.top})`);

    // Clear any existing legends
    svgContainer.select(".color-legend").remove();

    // Append color legend based on the color scheme
    if (colorScheme === 'rdBu') {
        createColorLegend(svg, rdBuColorScale, width, height);
    } else if (colorScheme === 'ylGn') {
        createColorLegend(svg, ylGnColorScale, width, height);
    }

    // Create scales
    const y = d3.scaleBand()
        .range([0, height])
        .domain(metrics)
        .padding(.1);

    const maxAverageValue = Math.max(...averages.map(a => Math.max(a.averageBrush1, a.averageBrush2)));
    const x = d3.scaleLinear()
        .domain([-maxAverageValue, maxAverageValue])
        .range([0, width - 60]);

    // Add Y axis
    const yAxis = svg.append("g").call(d3.axisLeft(y).tickSize(0))
        .attr("color", "white");

    yAxis.select(".domain").remove();

    // Define a diverging color scale
    const colorScaleR = d3.scaleDiverging()
        .domain([-1, 0, 1])
        .interpolator(d3.interpolateRdBu);

    const colorScaleB = d3.scaleDiverging()
        .domain([1, 0, -1])
        .interpolator(d3.interpolateRdBu);

    const colorScaleG = d3.scaleDiverging()
        .domain([1, 0, -1])
        .interpolator(d3.interpolateYlGn);

    svg.selectAll(".bar.brush1")
        .data(averages)
        .enter()
        .append("rect")
        .attr("class", "bar brush1")
        .attr("y", d => y(d.metric))
        .attr("x", d => x(-d.averageBrush1)) // Bars extend leftwards from the center
        .attr("height", y.bandwidth())
        .attr("fill", colorScaleBrush1)
        .attr("width", d => Math.abs(x(0) - x(-d.averageBrush1))); // Width is the absolute difference

    svg.selectAll(".bar.brush2")
        .data(averages)
        .enter()
        .append("rect")
        .attr("class", "bar brush2")
        .attr("y", d => y(d.metric))
        .attr("x", x(0)) // Bars start at the center and extend rightwards
        .attr("height", y.bandwidth())
        .attr("fill", colorScaleBrush2)
        .attr("width", d => Math.abs(x(0) - x(d.averageBrush2))); // Directly use the scale for width

    // Clear any existing axis before drawing a new one
    svg.selectAll(".x-axis").remove();

    // Create X axis
    const xAxis = d3.axisBottom(x)
        .tickSize(-height)
        .tickFormat(function(d) {
            return Math.abs(d).toFixed(1); // Convert negative values to positive and format
        });

    // Append the x-axis group
    svg.append("g")
        .attr("class", "x-axis") // Add a class for easy reference
        .attr("transform", `translate(0, ${height})`)
        .call(xAxis)
        .selectAll(".tick line")
        .attr("stroke", function(d) {
            return d < 0 ? "#fddbc7" : "#d1e5f0"; // Red for left side, Blue for right side
        });

    // Modify the colors of the labels
    svg.selectAll(".x-axis .tick text")
        .attr("fill", function(d) {
            return d < 0 ? "#fddbc7" : "#d1e5f0"; // Red for left side, Blue for right side
        });

    svg.select(".x-axis .domain").remove();

}

function calculateAverages(data, metrics, brush1Fighters, brush2Fighters) {
    return metrics.map(metric => {
        const metricValuesR1 = data.filter(fight => brush1Fighters.includes(fight.r_fighter))
            .map(fight => parseFloat(fight[`r_${metric}`]) || 0);
        const metricValuesB1 = data.filter(fight => brush1Fighters.includes(fight.b_fighter))
            .map(fight => parseFloat(fight[`b_${metric}`]) || 0);
        const metricValuesR2 = data.filter(fight => brush2Fighters.includes(fight.r_fighter))
            .map(fight => parseFloat(fight[`r_${metric}`]) || 0);
        const metricValuesB2 = data.filter(fight => brush2Fighters.includes(fight.b_fighter))
            .map(fight => parseFloat(fight[`b_${metric}`]) || 0);

        const totalValues1 = metricValuesR1.concat(metricValuesB1).reduce((acc, val) => acc + val, 0);
        const totalValues2 = metricValuesR2.concat(metricValuesB2).reduce((acc, val) => acc + val, 0);

        const average1 = totalValues1 / (metricValuesR1.length + metricValuesB1.length);
        const average2 = totalValues2 / (metricValuesR2.length + metricValuesB2.length);

        return { 
            metric, 
            averageBrush1: average1, 
            averageBrush2: average2 
        };
    });
}

function calculateCorrelations(data, metrics, brushFighters) {
    return metrics.map(metric => {
        const metricValuesR = data.filter(fight => brushFighters.includes(fight.r_fighter))
                                 .map(fight => parseFloat(fight[`r_${metric}`]) || 0);
        const metricValuesB = data.filter(fight => brushFighters.includes(fight.b_fighter))
                                 .map(fight => parseFloat(fight[`b_${metric}`]) || 0);
        const winsR = data.filter(fight => brushFighters.includes(fight.r_fighter))
                          .map(fight => fight.Winner === 'Red' ? 1 : 0);
        const winsB = data.filter(fight => brushFighters.includes(fight.b_fighter))
                          .map(fight => fight.Winner === 'Blue' ? 1 : 0);

        const combinedValues = metricValuesR.concat(metricValuesB);
        const combinedWins = winsR.concat(winsB);

        // Check if there are at least two data points
        if (combinedValues.length < 2 || combinedWins.length < 2) {
            return { metric, correlation: 0 }; // or another placeholder value
        }

        const correlation = ss.sampleCorrelation(combinedValues, combinedWins);
        return { metric, correlation: isNaN(correlation) ? 0 : correlation };
    });
}

function combineCorrelations(correlationsBrush1, correlationsBrush2) {
    // Combine the correlations of both brush groups
    return correlationsBrush1.map((correlation, i) => {
        return {
            metric: correlation.metric,
            brush1Correlation: correlation.correlation,
            brush2Correlation: correlationsBrush2[i].correlation
        };
    });
}

// Function to clear the pyramid chart
function clearPyramidChart() {
    const svgContainer = d3.select("#pyramidChart");
    svgContainer.selectAll("*").remove();
    // Add any additional logic for the default state or message here
}

// Function to handle dropdown menu state change
function handleDropdownChange() {
    const colorScheme = document.getElementById("colorSchemeSelect").value;
    const selectedOption = document.getElementById("dataOptionSelect").value;
    const useFilteredData = selectedOption === 'historic';

    // Call drawPyramidChart with the new useFilteredData value
    drawPyramidChart(fightsDataPath, currentBrush1Fighters, currentBrush2Fighters, useFilteredData, colorScheme);
}

// Add event listener to the dropdown menu
document.getElementById("dataOptionSelect").addEventListener('change', handleDropdownChange);

function handleColorSchemeChange() {
    const colorScheme = document.getElementById("colorSchemeSelect").value;
    const selectedOption = document.getElementById("dataOptionSelect").value;
    const useFilteredData = selectedOption === 'historic';
    drawPyramidChart(fightsDataPath, currentBrush1Fighters, currentBrush2Fighters, useFilteredData, colorScheme);
}

document.getElementById("colorSchemeSelect").addEventListener('change', handleColorSchemeChange);

// Example usage
drawPyramidChart(fightsDataPath, ['Adrian Yanez', 'Trevin Giles'], ['Gustavo Lopez', 'Roman Dolidze'], true);

export { drawPyramidChart, clearPyramidChart };