{PowerShell}
{ps,tools,utils}

### Update with oneliner ###

	(Invoke-WebRequest "http://live.sysinternals.com").Links | select href | % { Invoke-WebRequest ("http://live.sysinternals.com"+$_.href.ToString()) -OutFile (Join-Path "$PWD" $_.href.ToString()) -Verbose }

### Download all the tools from Sysinternals
Practice, practice, practice!
I really do want to learn PowerShell and to write...in English.

This snippet downloads all tools from [http://www.sysinternals.com/](http://www.sysinternals.com/) into a subfolder in the current directory.

		$global:sysinternals = "http://live.sysinternals.com"
		$dest = Join-Path $PWD "Sysinternals"
		$global:numberToDownload = 0


		function Download-File {
    		begin {
        		$count = 1
    		}
    		process {
		        $file = Join-Path $dest $_.innerHtml
		        $url = $global:sysinternals + $_.href
		        Write-Progress -Activity "Getting Sysinternals, total files: $global:numberToDownload" -CurrentOperation $url -PercentComplete ([System.Math]::Round($count/$global:numberToDownload, 2) * 100)
		        Write-Host $url
		        Invoke-WebRequest $url -OutFile $file
        
        		$count++
			    }
			}

			# Main
			
			if(!(Test-Path $dest)){ mkdir $dest }
			$wr = Invoke-WebRequest $sysinternals
			$global:numberToDownload = $wr.Links.Count
			
			$wr.Links | Download-File
    




   