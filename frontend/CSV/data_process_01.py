import pandas as pd
from sklearn.manifold import TSNE

def convert_percentage_to_float(percentage_str):
    if isinstance(percentage_str, str):
        return float(percentage_str.strip('%')) / 100
    return percentage_str  # In case the input is already in numeric format

# Load data from CSV
data = pd.read_csv('./raw_fighter_details.csv')

# Convert percentage strings to floats
for column in ['Str_Acc', 'Str_Def', 'TD_Acc', 'TD_Def']:
    data[column] = data[column].apply(convert_percentage_to_float)

# Select the specific columns for t-SNE
features = data[['SLpM', 'Str_Acc', 'SApM', 'Str_Def', 'TD_Avg', 'TD_Acc', 'TD_Def', 'Sub_Avg']]

# Filter out rows where all features are 0
filtered_data = data[(features != 0).any(axis=1)]

# Reset index to ensure alignment
filtered_data.reset_index(drop=True, inplace=True)

# Apply t-SNE on filtered data
tsne = TSNE(n_components=2, random_state=42)
tsne_results = tsne.fit_transform(filtered_data[features.columns])

# Create a DataFrame with the t-SNE results
tsne_df = pd.DataFrame(tsne_results, columns=['TSNE1', 'TSNE2'])

# Combine with the desired columns for easier identification
result_df = pd.concat([filtered_data[['fighter_name', 'Height', 'Weight', 'Reach', 'Stance']], tsne_df], axis=1)

# Save the results to a new CSV file
result_df.to_csv('TSNE_Fighter.csv', index=False)
