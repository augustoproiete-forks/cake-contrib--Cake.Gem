# coding: utf-8
lib = File.expand_path('../lib', __FILE__)
$LOAD_PATH.unshift(lib) unless $LOAD_PATH.include?(lib)
require 'testgem/version'

Gem::Specification.new do |spec|
  spec.name          = "testgem"
  spec.version       = Testgem::VERSION
  spec.authors       = ["Gary Ewan Park"]
  spec.email         = ["gep13@gep13.co.uk"]

  spec.summary       = "Test Gem for ensuring that Cake.Gem Addin is working"
  spec.description   = "Test Gem for ensuring that Cake.Gem Addin is working"
  spec.homepage      = "https://github.com/gep13/Cake.Gem"
  spec.license       = "MIT"

  spec.files         = `git ls-files -z`.split("\x0").reject { |f| f.match(%r{^(test|spec|features)/}) }
  spec.bindir        = "exe"
  spec.executables   = spec.files.grep(%r{^exe/}) { |f| File.basename(f) }
  spec.require_paths = ["lib"]

  spec.add_development_dependency "bundler", "~> 1.12"
  spec.add_development_dependency "rake", "~> 10.0"
end
