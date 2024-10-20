<?php

class ApiClient {
    private $apiKey;

    public function __construct($apiKey) {
        $this->apiKey = $apiKey;
    }

    public function callApi($url) {
        $ch = curl_init();
        curl_setopt($ch, CURLOPT_URL, $url);
        curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
        curl_setopt($ch, CURLOPT_HTTPHEADER, array("X-API-KEY: " . $this->apiKey));
        $response = curl_exec($ch);
        $httpCode = curl_getinfo($ch, CURLINFO_HTTP_CODE);
        curl_close($ch);

        if ($httpCode == 200) {
            return $response;
        } else {
            return "Error: " . $httpCode;
        }
    }
}

?>