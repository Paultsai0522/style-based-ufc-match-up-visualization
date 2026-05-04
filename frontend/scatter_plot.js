import { fightsDataPath } from "./config.js";

var svg = d3.select("#scatterPlot"),
    width = +svg.style("width").replace("px", ""),
    height = +svg.style("height").replace("px", "");

var activeBrush = 'brush1';  // Track the active brush
var brush1Selection, brush2Selection;  // Store selections for each brush

var x = d3.scaleLinear().range([50, width - 40]),
    y = d3.scaleLinear().range([height - 80, 40]);

var tooltip = d3.select("body").append("div")
    .attr("class", "tooltip")
    .style("opacity", 0);

// Brush definitions
var brush1 = d3.brush().extent([[0, 0], [width, height]]).on("end", brushed1);
var brush2 = d3.brush().extent([[0, 0], [width, height]]).on("end", brushed2);

var dots;
var data;
var fightData = [];

var xAxis = d3.axisBottom(x);
var yAxis = d3.axisLeft(y);

function updateBrushedArea(selection, brushId) {
    if (selection) {
        console.log("Active brush:", activeBrush);
        var [[x0, y0], [x1, y1]] = selection;
        console.log("Current brush:", brushId);
        console.log("Updated Brushed area:", x0, y0, x1, y1);
        dots.classed("selected", function(d) {
            return x0 <= x(d[currentXAxis]) && x(d[currentXAxis]) <= x1 && y0 <= y(d[currentYAxis]) && y(d[currentYAxis]) <= y1;
        });
        dots.style("opacity", function(d) {
            return x0 <= x(d[currentXAxis]) && x(d[currentXAxis]) <= x1 && y0 <= y(d[currentYAxis]) && y(d[currentYAxis]) <= y1 ? 0.5 : 0.1;
        });
    } else {
        dots.classed("selected", false);
        dots.style("opacity", 0.9); // Reset opacity when brush is cleared
    }
}

// Define brush behaviors but don't attach them yet
var brushBehavior1 = d3.brush().extent([[0, 0], [width, height]]).on("end", brushed1);
var brushBehavior2 = d3.brush().extent([[0, 0], [width, height]]).on("end", brushed2);

// Create g elements for brushes but without the brush behavior attached
var gBrush1 = svg.append("g").attr("class", "brush1");
var gBrush2 = svg.append("g").attr("class", "brush2");

// Function to dynamically attach/detach brush behaviors
function toggleBrushes() {
    if (activeBrush === 'brush1') {
        gBrush1.call(brushBehavior1); // Attach brush1 behavior
        gBrush2.selectAll('.overlay').remove(); // Remove brush2 behavior
    } else {
        gBrush1.selectAll('.overlay').remove(); // Remove brush1 behavior
        gBrush2.call(brushBehavior2); // Attach brush2 behavior
    }
}

// Button event listeners to switch and activate brushes
d3.select("#brush1Btn").on("click", function() {
    activeBrush = 'brush1';
    toggleBrushes();
});

d3.select("#brush2Btn").on("click", function() {
    activeBrush = 'brush2';
    toggleBrushes();
});

// Initialize with brush1 active
toggleBrushes();

function setBrushSelection(brush, selection, brushG, brushedHandler) {
    brush.on("end", null); // Temporarily disable the brushed event handler
    brushG.call(brush.move, selection); // Set the brush selection
    brush.on("end", brushedHandler); // Re-enable the specific brushed event handler
}

function tagBrushedPoints(selection, brushTag) {
    console.log("Tagging points for:", brushTag);
    // First, clear existing selections for the active brush
    data.forEach(function(d) {
        d[brushTag] = false;
    });

    // Then, tag new selections
    var [[x0, y0], [x1, y1]] = selection;
    data.forEach(function(d) {
        if (x0 <= x(d[currentXAxis]) && x(d[currentXAxis]) <= x1 && y0 <= y(d[currentYAxis]) && y(d[currentYAxis]) <= y1) {
            d[brushTag] = true;
        }
    });

    updateDotsStyle();
}

function updateDotsStyle() {
    // Check if any dot is selected by either brush
    var anySelected = data.some(function(d) {
        return d.brush1Selected || d.brush2Selected;
    });

    dots.style("opacity", function(d) {
        if (anySelected) {
            // If any dot is selected, highlight selected dots and dim others
            return d.brush1Selected || d.brush2Selected ? 0.75 : 0.1;
        } else {
            // If no dots are selected, set all dots to initial opacity
            return 0.9;
        }
    });
}

function brushed1(event) {
    if (event.selection === null) {
        data.forEach(d => d.brush1Selected = false);
    } else {
        brush1Selection = event.selection;
        tagBrushedPoints(brush1Selection, 'brush1Selected');
    }
    updateDotsStyle();
    findAndDrawFights(fightData); // Call after updating selections
    countWinners();
    updatePyramidChart();
}

function brushed2(event) {
    if (event.selection === null) {
        data.forEach(d => d.brush2Selected = false);
    } else {
        brush2Selection = event.selection;
        tagBrushedPoints(brush2Selection, 'brush2Selected');
    }
    updateDotsStyle();
    findAndDrawFights(fightData); // Call after updating selections
    countWinners();
    updatePyramidChart();
}

let highlightedRFighter = null;
let highlightedBFighter = null;

function updateHighlightedFighters() {
    // Reset all highlights
    dots.style("stroke", null).style("stroke-width", null)
        .attr("r", 2);

    // Re-apply highlights for currently selected fighters
    if (highlightedRFighter) {
        dots.filter(d => d.fighter_name === highlightedRFighter)
            .style("stroke", "#e5283f")
            .style("stroke-width", "2.5px")
            .attr("r", 3);
    }

    if (highlightedBFighter) {
        dots.filter(d => d.fighter_name === highlightedBFighter)
            .style("stroke", "#2f88e3")
            .style("stroke-width", "2.5px")
            .attr("r", 3);
    }
}

d3.select("#RfighterSearch").on("input", function() {
    var searchValue = d3.select(this).property("value");
    console.log("searching R fighter:", searchValue);

    highlightedRFighter = searchValue;
    updateHighlightedFighters();
});

d3.select("#BfighterSearch").on("input", function() {
    var searchValue = d3.select(this).property("value");
    console.log("searching B fighter:", searchValue);

    highlightedBFighter = searchValue;
    updateHighlightedFighters();
});


var currentXAxis = "TSNE1";
var currentYAxis = "TSNE2";
var svg, x, y, dots, data;

function updateAxis(axisType, selectedValue) {
    if (axisType === "x") {
        currentXAxis = selectedValue;
    } else {
        currentYAxis = selectedValue;
    }
    updateScatterPlot(); // Redraw the scatter plot with new axes
    clearBrushesAndSelections();
}

function updateScatterPlot() {
    // Update the scales based on the current axis selections
    x.domain(d3.extent(data, d => d[currentXAxis]));
    y.domain(d3.extent(data, d => d[currentYAxis]));

    // Remove existing dots
    svg.selectAll(".dot").remove();

    // Create new dots with updated positions
    dots = svg.selectAll(".dot")
        .data(data)
        .enter().append("circle")
        .attr("class", "dot")
        .attr("r", 2)
        .style("fill", "white")
        .style("opacity", 0.9)
        .attr("cx", d => x(d[currentXAxis]))
        .attr("cy", d => y(d[currentYAxis]));

    // Add mouseover events for tooltips
    dots.on("mouseover", function(event, d) {
        tooltip.transition().duration(200).style("opacity", 0.95);
        tooltip.html(createTooltipContent(d))
            .style("left", (event.pageX + 10) + "px")
            .style("top", (event.pageY - 10) + "px");
    }).on("mouseout", function(d) {
        tooltip.transition().duration(500).style("opacity", 0);
    });

    // Apply force simulation only for TSNE1 and TSNE2
    if (currentXAxis === "TSNE1" && currentYAxis === "TSNE2") {
        var simulation = d3.forceSimulation(data)
            .force("x", d3.forceX(d => x(d[currentXAxis])).strength(0.5))
            .force("y", d3.forceY(d => y(d[currentYAxis])).strength(0.5))
            .force("collide", d3.forceCollide(3));

        // Manually run the simulation for a fixed number of iterations
        const totalIterations = 150; // You can adjust this number
        for (let i = 0; i < totalIterations; ++i) {
            simulation.tick();
        }

        // Update positions after simulation
        dots.attr("cx", d => d.x).attr("cy", d => d.y);
    } else {
        // Directly update positions
        var simulation = d3.forceSimulation(data)
            .force("x", d3.forceX(d => x(d[currentXAxis])).strength(0.5))
            .force("y", d3.forceY(d => y(d[currentYAxis])).strength(0.5))
            .force("collide", d3.forceCollide(1));

        // Manually run the simulation for a fixed number of iterations
        const totalIterations = 150; // You can adjust this number
        for (let i = 0; i < totalIterations; ++i) {
            simulation.tick();
        }

        // Update positions after simulation
        dots.attr("cx", d => d.x).attr("cy", d => d.y);
    }

    // Append X axis to SVG
    svg.append("g")
    .attr("class", "x axis")
    .attr("transform", "translate(0," + (height - 60) + ")") // Adjust Y position of X axis
    .attr("color", "white")
    .call(xAxis);

    // Append Y axis to SVG
    svg.append("g")
    .attr("class", "y axis")
    .attr("transform", "translate(30,0)") // Adjust X position of Y axis
    .attr("color", "white")
    .call(yAxis);

}

// Helper function to create tooltip content
function createTooltipContent(d) {
    // Customize this function to display the desired tooltip content
    return "Fighter: " + d.fighter_name + "<br/>" +
    currentXAxis + ": " + d[currentXAxis] + "<br/>" +
    currentYAxis + ": " + d[currentYAxis] + "<br/>" +
    "Height: " + d.Height + "<br/>" +
    "Weight: " + d.Weight + "<br/>" +
    "Reach: " + d.Reach + "<br/>" +
    "Stance: " + d.Stance;
}

// Event listeners for axis dropdowns
d3.select("#xAxisSelect").on("change", function() {
    var selectedValue = d3.select(this).property("value");
    updateAxis("x", selectedValue);
});

d3.select("#yAxisSelect").on("change", function() {
    var selectedValue = d3.select(this).property("value");
    updateAxis("y", selectedValue);
});

// Function to clear brushes and fighter selections
function clearBrushesAndSelections() {
    console.log("clearBrushesAndSelections");
    console.log("brush1Selection:", brush1Selection);
    console.log("brush2Selection:", brush2Selection);
    // Clear brush areas only if a brush selection exists
    if (brush1Selection) {
        gBrush1.call(brush1.move, null);
    }
    if (brush2Selection) {
        gBrush2.call(brush2.move, null);
    }

    // Reset brush selections
    brush1Selection = null;
    brush2Selection = null;

    // Clear fighter selections
    data.forEach(function(d) {
        d.brush1Selected = false;
        d.brush2Selected = false;
    });

    // Update dot styles and remove any drawn arcs
    updateDotsStyle();
    svg.selectAll("path.arc").remove();
    svg.select(".x.axis").remove();
    svg.select(".y.axis").remove();
}

// Function to parse and format specific data fields
function parseDataField(fieldValue, fieldName) {
    // Check if fieldValue is empty or undefined
    if (!fieldValue) {
        return null; // or return 0, depending on how you want to handle missing values
    }

    if (fieldName === "Height") {
        // Example: Convert '5' 11""' to a numerical value in inches
        var matches = fieldValue.match(/(\d+)' (\d+)"/);
        if (matches) {
            return parseInt(matches[1]) * 12 + parseInt(matches[2]);
        } else {
            return null; // or 0 if the format doesn't match
        }
    } else if (fieldName === "Reach") {
        // Example: Convert '71""' to numerical value
        return parseFloat(fieldValue.replace("\"", "")) || null;
    } else if (fieldName === "Weight") {
        // Example: Convert '235 lbs.' to numerical value
        return parseFloat(fieldValue.replace(" lbs.", "")) || null;
    }
    return fieldValue; // Return original value for other fields
}

d3.csv("./CSV/TSNE_Fighter.csv")
.then(function(loadedData) {
    data = loadedData.map(d => {
        Object.keys(d).forEach(key => {
            d[key] = parseDataField(d[key], key);
        });
        return d;
    });

    data.forEach(function(d) {
        d.TSNE1 = +d.TSNE1;
        d.TSNE2 = +d.TSNE2;
        d.brush1Selected = false; // Initialize selection flags
        d.brush2Selected = false;
    });

    dots = svg.selectAll(".dot")
        .data(data)
        .enter().append("circle")
        .attr("class", "dot")
        .attr("r", 2)
        .style("fill", "white")
        .style("opacity", 0.9)
        .attr("cx", function(d) { return d.x; })
        .attr("cy", function(d) { return d.y; });

    updateScatterPlot();
}).catch(error => {
    console.error("Error loading data:", error);
});

function drawArc(fighter1, fighter2, winner) {
    var gradientId = `gradient-${Math.random().toString(36).substr(2, 9)}`; // Unique ID for each gradient

    // Create a unique gradient for each arc
    var gradient = svg.select("defs")
        .append("linearGradient")
        .attr("id", gradientId);

    // Determine the start and end colors based on the winner
    var startColor = winner === fighter1 ? "#67a9cf" : "#ef8a62";
    var endColor = winner === fighter1 ? "#ef8a62" : "#67a9cf";
    // var startColor = winner === fighter1 ? "#ffffff" : "#ffffff";
    // var endColor = winner === fighter1 ? "#ffffff" : "#ffffff";

    gradient.append("stop")
        .attr("offset", "0%")
        .attr("stop-color", startColor);

    gradient.append("stop")
        .attr("offset", "100%")
        .attr("stop-color", endColor);

    // Adjust gradient direction based on fighter positions
    var xDiff = x(fighter2[currentXAxis]) - x(fighter1[currentXAxis]);
    var yDiff = y(fighter2[currentYAxis]) - y(fighter1[currentYAxis]);
    gradient.attr("x1", xDiff < 0 ? "100%" : "0%")
            .attr("y1", yDiff < 0 ? "100%" : "0%")
            .attr("x2", xDiff < 0 ? "0%" : "100%")
            .attr("y2", yDiff < 0 ? "0%" : "100%");

    // Draw the arc
    var path = d3.path();
    path.moveTo(x(fighter1[currentXAxis]), y(fighter1[currentYAxis]));
    var midX = (x(fighter1[currentXAxis]) + x(fighter2[currentXAxis])) / 2;
    var midY = (y(fighter1[currentYAxis]) + y(fighter2[currentYAxis])) / 2 - 20; // Adjust for the arc's height
    path.quadraticCurveTo(midX, midY, x(fighter2[currentXAxis]), y(fighter2[currentYAxis]));

    svg.append("path")
        .attr("d", path.toString())
        .attr("fill", "none")
        .attr("opacity", "0.75")
        .attr("stroke", `url(#${gradientId})`)
        .attr("stroke-width", "1px") // Adjust stroke width for visibility
        .attr("class", "arc");

    console.log("Arc path:", path.toString()); // For debugging
}

function findAndDrawFights(fightData) {
    // Remove existing arcs
    svg.selectAll("path.arc").remove();

    fightData.forEach(fight => {
        var fighter1 = data.find(d => d.fighter_name === fight.r_fighter);
        var fighter2 = data.find(d => d.fighter_name === fight.b_fighter);
        if (fighter1 && fighter2) {
            if ((fighter1.brush1Selected && fighter2.brush2Selected) || (fighter1.brush2Selected && fighter2.brush1Selected)) {
                var winner = fight.Winner === "Red" ? fighter1 : fighter2;
                console.log("winner:", winner);                
                drawArc(fighter1, fighter2, winner);
            }
        }
    });
}

// Load the fights data
async function loadFightData() {
    try {
        const response = await fetch(fightsDataPath);
        const loadedFightData = await response.json();
        fightData = loadedFightData;
    }
    catch (error) {
        console.error("Error loading fight data:", error);
    }
}

loadFightData();

function countWinners() {
    let winnersCount = {
        brush1: 0,
        brush2: 0
    };

    fightData.forEach(fight => {
        let fighter1 = data.find(d => d.fighter_name === fight.r_fighter);
        let fighter2 = data.find(d => d.fighter_name === fight.b_fighter);

        if (fighter1 && fighter2) {
            if ((fighter1.brush1Selected && fighter2.brush2Selected) || (fighter1.brush2Selected && fighter2.brush1Selected)) {
                let winner = fight.Winner === "Red" ? fighter1 : fighter2;
                if (winner.brush1Selected) {
                    winnersCount.brush1 += 1;
                } else if (winner.brush2Selected) {
                    winnersCount.brush2 += 1;
                }
            }
        }
    });

    const totalWins = winnersCount.brush1 + winnersCount.brush2;
    const redWinPercentage = totalWins > 0 ? winnersCount.brush1 / totalWins : 0;
    const blueWinPercentage = totalWins > 0 ? winnersCount.brush2 / totalWins : 0;

    drawWinningPercentageBar(redWinPercentage, blueWinPercentage);
}

function drawWinningPercentageBar(redWinPercentage, blueWinPercentage) {
    const barWidth = 250;  // Set the total width of the bar
    const barHeight = 20;  // Set the height of the bar
    const barX = width - barWidth - 10;  // Position the bar 10px from the right
    const barY = 0;  // Position the bar 10px from the top
    const textPadding = 5; // Padding for text inside the bar

    // Clear any existing bars and texts
    svg.selectAll(".winning-percentage-bar, .winning-percentage-text").remove();

    // Create the bar for red wins
    const redBarWidth = barWidth * redWinPercentage;
    svg.append("rect")
        .attr("class", "winning-percentage-bar")
        .attr("x", barX)
        .attr("y", barY)
        .attr("width", redBarWidth)
        .attr("height", barHeight)
        .attr("fill", "#ef8a62");

    // Create the bar for blue wins
    const blueBarWidth = barWidth * blueWinPercentage;
    svg.append("rect")
        .attr("class", "winning-percentage-bar")
        .attr("x", barX + redBarWidth)
        .attr("y", barY)
        .attr("width", blueBarWidth)
        .attr("height", barHeight)
        .attr("fill", "#67a9cf");

    // Append text for red win percentage
    if (redBarWidth > textPadding * 2) {
        svg.append("text")
            .attr("class", "winning-percentage-text")
            .attr("x", barX + redBarWidth / 2)
            .attr("y", barY + barHeight / 2)
            .attr("dy", "0.35em")
            .attr("text-anchor", "middle")
            .attr("fill", "white")
            .text(`${(redWinPercentage * 100).toFixed(0)}%`);
    }

    // Append text for blue win percentage
    if (blueBarWidth > textPadding * 2) {
        svg.append("text")
            .attr("class", "winning-percentage-text")
            .attr("x", barX + redBarWidth + blueBarWidth / 2)
            .attr("y", barY + barHeight / 2)
            .attr("dy", "0.35em")
            .attr("text-anchor", "middle")
            .attr("fill", "white")
            .text(`${(blueWinPercentage * 100).toFixed(0)}%`);
    }
}

import { drawPyramidChart } from "./pyramidChart.js";

function updatePyramidChart() {
    // Extract names of fighters in brush1 and brush2
    const brush1Fighters = data.filter(d => d.brush1Selected).map(d => d.fighter_name);
    const brush2Fighters = data.filter(d => d.brush2Selected).map(d => d.fighter_name);

    // Determine whether to use filtered data based on dropdown menu selection
    const selectedOption = document.getElementById("dataOptionSelect").value;
    const useFilteredData = selectedOption === 'historic';
    const colorScheme = document.getElementById("colorSchemeSelect").value;

    // Check if both brushes have selected fighters
    if (brush1Fighters.length > 0 && brush2Fighters.length > 0) {
        drawPyramidChart(fightsDataPath, brush1Fighters, brush2Fighters, useFilteredData, colorScheme);
    }
}
